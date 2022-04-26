using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace LMS.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : CommonController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult Class(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult Assignment(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }


        public IActionResult ClassListings(string subject, string num)
        {
            System.Diagnostics.Debug.WriteLine(subject + num);
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            return View();
        }


        /*******Begin code to modify********/

        /// <summary>
        /// Returns a JSON array of the classes the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester
        /// "year" - The year part of the semester
        /// "grade" - The grade earned in the class, or "--" if one hasn't been assigned
        /// </summary>
        /// <param name="uid">The uid of the student</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {
            using (db = new Team103LMSContext())
            {
                var query = from e in db.Enrolled
                            where e.Student == uid
                            join c in db.Classes
                            on e.Class equals c.ClassId
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            select new
                            {
                                subject = course.Department,
                                number = course.Number,
                                name = course.Name,
                                season = c.Season,
                                year = c.Year,
                                grade = e.Grade,
                            };
                foreach (var x in query)
                {
                    Debug.WriteLine(x.name, x.grade);
                }
                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// Returns a JSON array of all the assignments in the given class that the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The category name that the assignment belongs to
        /// "due" - The due Date/Time
        /// "score" - The score earned by the student, or null if the student has not submitted to this assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="uid"></param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInClass(string subject, int num, string season, int year, string uid)
        {
            using (var db = new Team103LMSContext())
            {
                var query = from course in db.Courses
                            where course.Department == subject && course.Number == num
                            join c in db.Classes
                            on course.CatalogId equals c.Listing
                            where c.Season == season && c.Year == year
                            join e in db.Enrolled
                            on c.ClassId equals e.Class
                            where e.Student == uid
                            join cat in db.AssignmentCategories
                            on c.ClassId equals cat.InClass
                            join a in db.Assignments
                            on cat.CategoryId equals a.Category
                            select new
                            {
                                aname = a.Name,
                                cname = cat.Name,
                                due = a.Due,
                                score = !(from s in db.Submissions
                                          where s.Assignment == a.AssignmentId  && s.Student == uid
                                          select s.Score).Any() ? null : (uint?)(from s in db.Submissions
                                                                                 where s.Assignment == a.AssignmentId && s.Student == uid
                                                                                 select s.Score).First()
                            };

                
                return Json(query.ToArray());
            }
        }
    



    /// <summary>
    /// Adds a submission to the given assignment for the given student
    /// The submission should use the current time as its DateTime
    /// You can get the current time with DateTime.Now
    /// The score of the submission should start as 0 until a Professor grades it
    /// If a Student submits to an assignment again, it should replace the submission contents
    /// and the submission time (the score should remain the same).
	/// Does *not* automatically reject late submissions.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The new assignment name</param>
    /// <param name="uid">The student submitting the assignment</param>
    /// <param name="contents">The text contents of the student's submission</param>
    /// <returns>A JSON object containing {success = true/false}.</returns>
    public IActionResult SubmitAssignmentText(string subject, int num, string season, int year, 
      string category, string asgname, string uid, string contents)
    {
            using (db)
            {
                var submissions = from cat in db.AssignmentCategories
                    where cat.Name == category
                    join a in db.Assignments
                        on cat.CategoryId equals a.Category
                    where a.Name == asgname
                    join s in db.Submissions
                        on a.AssignmentId equals s.Assignment
                    where s.Student == uid
                    select s;

                var assignment = from cat in db.AssignmentCategories
                    where cat.Name == category
                    join a in db.Assignments on cat.CategoryId equals a.Category
                    where a.Name == asgname
                    select a.AssignmentId;

                if (submissions.Any())
                {
                    var oldSubmit = submissions.FirstOrDefault();
                    oldSubmit.SubmissionContents = contents;
                    oldSubmit.Student = uid;
                    oldSubmit.Assignment = oldSubmit.Assignment;
                    oldSubmit.Time = DateTime.Now;
                    oldSubmit.Score = 0;
                }
                else
                {
                    Submissions newSubmit = new Submissions();
                    newSubmit.SubmissionContents = contents;
                    newSubmit.Student = uid;
                    newSubmit.Assignment = assignment.First();
                    newSubmit.Time = DateTime.Now;
                    newSubmit.Score = 0;

                    db.Submissions.Add(newSubmit);
                }


                try
                { db.SaveChanges(); }
                catch (DbUpdateException e)
                {
                    return Json(new { success = false });
                }

                return Json(new { success = true });
            }
        }

    
    /// <summary>
    /// Enrolls a student in a class.
    /// </summary>
    /// <param name="subject">The department subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester</param>
    /// <param name="year">The year part of the semester</param>
    /// <param name="uid">The uid of the student</param>
    /// <returns>A JSON object containing {success = {true/false},
	/// false if the student is already enrolled in the Class.</returns>
    public IActionResult Enroll(string subject, int num, string season, int year, string uid)
    {
            using (db)
            {
                var query = from c in db.Classes
                            where c.Season == season && c.Year == year
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            where course.Department == subject && course.Number == num
                            select c.ClassId;

                Enrolled newEnroll = new Enrolled();
                newEnroll.Student = uid;
                newEnroll.Class = query.FirstOrDefault();
                newEnroll.Grade = "--";

                db.Enrolled.Add(newEnroll);

                try
                { db.SaveChanges(); }
                catch (DbUpdateException e)
                {
                    return Json(new { success = false });
                }

                return Json(new { success = true });
            }
    }



    /// <summary>
    /// Calculates a student's GPA
    /// A student's GPA is determined by the grade-point representation of the average grade in all their classes.
    /// Assume all classes are 4 credit hours.
    /// If a student does not have a grade in a class ("--"), that class is not counted in the average.
    /// If a student does not have any grades, they have a GPA of 0.0.
    /// Otherwise, the point-value of a letter grade is determined by the table on this page:
    /// https://advising.utah.edu/academic-standards/gpa-calculator-new.php
    /// </summary>
    /// <param name="uid">The uid of the student</param>
    /// <returns>A JSON object containing a single field called "gpa" with the number value</returns>
    public IActionResult GetGPA(string uid)
    {
            var query = from e in db.Enrolled
                             where e.Student == uid
                             select e;

            double GPA = 0.0;
            double count = 0;

            foreach (var c in query)
            {
                if (c.Grade != "--")
                {
                    count += 4;
                    switch (c.Grade)
                    {
                        case "A":
                            GPA += 4.0 * 4;
                            break;
                        case "A-":
                            GPA += 3.7 * 4;
                            break;
                        case "B+":
                            GPA += 3.3 * 4;
                            break;
                        case "B":
                            GPA += 3.0 * 4;
                            break;
                        case "B-":
                            GPA += 2.7 * 4;
                            break;
                        case "C+":
                            GPA += 2.3 * 4;
                            break;
                        case "C":
                            GPA += 2.0 * 4;
                            break;
                        case "C-":
                            GPA += 1.7 * 4;
                            break;
                        case "D+":
                            GPA += 1.3 * 4;
                            break;
                        case "D":
                            GPA += 1.0 * 4;
                            break;
                        case "D-":
                            GPA += 0.7 * 4;
                            break;
                    }
                }
            }

            if (count > 0)
                GPA = GPA / count;
            else
                GPA = 0.0;
            
            return Json(new { gpa = GPA });
    }

    /*******End code to modify********/

  }
}