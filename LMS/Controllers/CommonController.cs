using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    public class CommonController : Controller
    {
        /*******Begin code to modify********/
        protected Team103LMSContext db;

        public CommonController()
        {
            db = new Team103LMSContext();
        }

        /*
         * WARNING: This is the quick and easy way to make the controller
         *          use a different LibraryContext - good enough for our purposes.
         *          The "right" way is through Dependency Injection via the constructor 
         *          (look this up if interested).
        */
        public void UseLMSContext(Team103LMSContext ctx)
        {
            db = ctx;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }


        /// <summary>
        /// Retreive a JSON array of all departments from the database.
        /// Each object in the array should have a field called "name" and "subject",
        /// where "name" is the department name and "subject" is the subject abbreviation.
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetDepartments()
        {
            using (db)
            {
                var query =
                    from d in db.Departments
                    select d;

                return Json(query.ToArray());
            }
        }


        /// <summary>
        /// Returns a JSON array representing the course catalog.
        /// Each object in the array should have the following fields:
        /// "subject": The subject abbreviation, (e.g. "CS")
        /// "dname": The department name, as in "Computer Science"
        /// "courses": An array of JSON objects representing the courses in the department.
        ///            Each field in this inner-array should have the following fields:
        ///            "number": The course number (e.g. 5530)
        ///            "cname": The course name (e.g. "Database Systems")
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetCatalog()
        {
            using (db)
            {
                var query =
                    from d in db.Departments
                    select new
                    {
                        subject = d.Subject, dname = d.Name,
                        courses = from c in db.Courses
                            where c.Department == d.Subject
                            select new {number = c.Number, cname = c.Name}
                    };

                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// Returns a JSON array of all class offerings of a specific course.
        /// Each object in the array should have the following fields:
        /// "season": the season part of the semester, such as "Fall"
        /// "year": the year part of the semester
        /// "location": the location of the class
        /// "start": the start time in format "hh:mm:ss"
        /// "end": the end time in format "hh:mm:ss"
        /// "fname": the first name of the professor
        /// "lname": the last name of the professor
        /// </summary>
        /// <param name="subject">The subject abbreviation, as in "CS"</param>
        /// <param name="number">The course number, as in 5530</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetClassOfferings(string subject, int number)
        {
            using (db)
            {
                var query =
                    from crs in db.Courses
                    join cls in db.Classes on crs.CatalogId equals cls.Listing into offerings
                    from o in offerings
                    join p in db.Professors on o.TaughtBy equals p.UId
                    where (crs.Department == subject && crs.Number == number)
                    select new
                    {
                        season = o.Season, year = o.Year, location = o.Location, start = o.StartTime, end = o.EndTime,
                        fname = p.FName, lname = p.LName
                    };
                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <returns>The assignment contents</returns>
        public IActionResult GetAssignmentContents(string subject, int num, string season, int year, string category,
            string asgname)
        {
            using (db)
            {
                var query = from crs in db.Courses
                    where crs.Department == subject && crs.Number == num
                    join cls in db.Classes
                        on crs.CatalogId equals cls.Listing
                    where cls.Season == season && cls.Year == year
                    join ac in db.AssignmentCategories
                        on cls.ClassId equals ac.InClass
                    where ac.Name == category
                    join a in db.Assignments
                        on ac.CategoryId equals a.Category
                    where a.Name == asgname
                    select a.Contents;

                return Content(query.First());
            }
        }


        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment submission.
        /// Returns the empty string ("") if there is no submission.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <param name="uid">The uid of the student who submitted it</param>
        /// <returns>The submission text</returns>
        public IActionResult GetSubmissionText(string subject, int num, string season, int year, string category,
            string asgname, string uid)
        {
            using (db)
            {
                var query = from crs in db.Courses
                    where crs.Department == subject && crs.Number == num
                    join cls in db.Classes
                        on crs.CatalogId equals cls.Listing
                    where cls.Season == season && cls.Year == year
                    join ac in db.AssignmentCategories
                        on cls.ClassId equals ac.InClass
                    where ac.Name == category
                    join a in db.Assignments
                        on ac.CategoryId equals a.Category
                    where a.Name == asgname
                    join s in db.Submissions
                        on a.AssignmentId equals s.Assignment
                    where s.Student == uid
                    select s;
                if (!query.Any())
                {
                    return Content("");
                }
                else
                {
                    return Content(query.First().SubmissionContents);
                }
                
            }
        }


        /// <summary>
        /// Gets information about a user as a single JSON object.
        /// The object should have the following fields:
        /// "fname": the user's first name
        /// "lname": the user's last name
        /// "uid": the user's uid
        /// "department": (professors and students only) the name (such as "Computer Science") of the department for the user. 
        ///               If the user is a Professor, this is the department they work in.
        ///               If the user is a Student, this is the department they major in.    
        ///               If the user is an Administrator, this field is not present in the returned JSON
        /// </summary>
        /// <param name="uid">The ID of the user</param>
        /// <returns>
        /// The user JSON object 
        /// or an object containing {success: false} if the user doesn't exist
        /// </returns>
        public IActionResult GetUser(string uid)
        {
            using (db)
            {
                //Query for all users
                var adminQuery = from a in db.Administrators where a.UId == uid select a;
                var studentQuery = from s in db.Students where s.UId == uid select s;
                var professorQuery = from p in db.Professors where p.UId == uid select p;

                if (adminQuery.Any())
                    return Json(new
                    {
                        fname = adminQuery.First().FName, lname = adminQuery.First().LName, uid = adminQuery.First().UId
                    });
                else if (studentQuery.Any())
                    return Json(new
                    {
                        fname = studentQuery.First().FName, lname = studentQuery.First().LName,
                        uid = studentQuery.First().UId, department = studentQuery.First().Major
                    });
                else if (professorQuery.Any())
                    return Json(new
                    {
                        fname = professorQuery.First().FName, lname = professorQuery.First().LName,
                        uid = professorQuery.First().UId, department = professorQuery.First().WorksIn
                    });
            }

            return Json(new {success = false});
        }


        /*******End code to modify********/
    }
}