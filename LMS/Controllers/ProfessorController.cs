using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Models.LMSModels;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
  [Authorize(Roles = "Professor")]
  public class ProfessorController : CommonController
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Students(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
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

    public IActionResult Categories(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      return View();
    }

    public IActionResult CatAssignments(string subject, string num, string season, string year, string cat)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
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

    public IActionResult Submissions(string subject, string num, string season, string year, string cat, string aname)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      return View();
    }

    public IActionResult Grade(string subject, string num, string season, string year, string cat, string aname, string uid)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      ViewData["uid"] = uid;
      return View();
    }

    /*******Begin code to modify********/


    /// <summary>
    /// Returns a JSON array of all the students in a class.
    /// Each object in the array should have the following fields:
    /// "fname" - first name
    /// "lname" - last name
    /// "uid" - user ID
    /// "dob" - date of birth
    /// "grade" - the student's grade in this class
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetStudentsInClass(string subject, int num, string season, int year)
    {
            using (var db = new Team103LMSContext())
            {
                var query = from  c in db.Classes
                            where c.Season == season & c.Year == year
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            where course.Department == subject & course.Number == num
                            join e in db.Enrolled
                            on c.ClassId equals e.Class
                            join s in db.Students
                            on e.Student equals s.UId
                            select new
                            {
                                fname = s.FName,
                                lname = s.LName,
                                uid = s.UId,
                                dob = s.Dob,
                                grade = e.Grade
                            };
                return Json(query.ToArray());
            }
    }



    /// <summary>
    /// Returns a JSON array with all the assignments in an assignment category for a class.
    /// If the "category" parameter is null, return all assignments in the class.
    /// Each object in the array should have the following fields:
    /// "aname" - The assignment name
    /// "cname" - The assignment category name.
    /// "due" - The due DateTime
    /// "submissions" - The number of submissions to the assignment
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class, 
    /// or null to return assignments from all categories</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentsInCategory(string subject, int num, string season, int year, string category)
    {
            using (var db = new Team103LMSContext())
            {
                if (category is null)
                {
                    var query = from c in db.Classes
                                     where c.Season == season && c.Year == year
                                     join course in db.Courses
                                     on c.Listing equals course.CatalogId
                                     where course.Department == subject && course.Number == num
                                     join cat in db.AssignmentCategories
                                     on c.ClassId equals cat.InClass
                                     join a in db.Assignments
                                     on cat.CategoryId equals a.Category
                                     select new
                                     {
                                         aname = a.Name,
                                         cname = cat.Name,
                                         due = a.Due,
                                         submissions = a.Submissions.Count(),
                                     };

                    return Json(query.ToArray());
                }
                else
                {
                    var query = from a in db.Assignments
                                join cat in db.AssignmentCategories
                                on a.Category equals cat.CategoryId
                                where cat.Name == category
                                join c in db.Classes
                                on cat.InClass equals c.ClassId
                                where c.Season == season && c.Year == year
                                join course in db.Courses
                                on c.Listing equals course.CatalogId
                                where course.Department == subject && course.Number == num
                                select new {
                                    aname = a.Name,
                                    cname = cat.Name,
                                    due = a.Due,
                                    submissions = a.Submissions.Count(),
                                };

                    return Json(query.ToArray());
                }
            }
        }


    /// <summary>
    /// Returns a JSON array of the assignment categories for a certain class.
    /// Each object in the array should have the folling fields:
    /// "name" - The category name
    /// "weight" - The category weight
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentCategories(string subject, int num, string season, int year)
    {
            using (var db = new Team103LMSContext())
            {
                var query = from c in db.Classes
                                 where c.Season == season && c.Year == year
                                 join course in db.Courses
                                 on c.Listing equals course.CatalogId
                                 where course.Department == subject && course.Number == num
                                 join cat in db.AssignmentCategories
                                 on  c.ClassId equals cat.InClass
                                 select new
                                 {
                                     name = cat.Name,
                                     weight = cat.Weight
                                 };

                return Json(query.ToArray());
            }
        }

    /// <summary>
    /// Creates a new assignment category for the specified class.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The new category name</param>
    /// <param name="catweight">The new category weight</param>
    /// <returns>A JSON object containing {success = true/false},
    ///	false if an assignment category with the same name already exists in the same class.</returns>
    public IActionResult CreateAssignmentCategory(string subject, int num, string season, int year, string category, int catweight)
    {
            //call helper method to update grades for all students in class 

            using (var db = new Team103LMSContext())
            {
                var query = from c in db.Classes
                            where c.Season == season & c.Year == year
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            where course.Department == subject & course.Number == num
                            select c.ClassId;

                AssignmentCategories newCat = new AssignmentCategories();
                newCat.Name = category;
                newCat.Weight = (uint)catweight;
                newCat.InClass = query.First();

                db.AssignmentCategories.Add(newCat);

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
    /// Creates a new assignment for the given class and category.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The new assignment name</param>
    /// <param name="asgpoints">The max point value for the new assignment</param>
    /// <param name="asgdue">The due DateTime for the new assignment</param>
    /// <param name="asgcontents">The contents of the new assignment</param>
    /// <returns>A JSON object containing success = true/false,
	/// false if an assignment with the same name already exists in the same assignment category.</returns>
    public IActionResult CreateAssignment(string subject, int num, string season, int year, string category, string asgname, int asgpoints, DateTime asgdue, string asgcontents)
    {
            using (var db = new Team103LMSContext())
            {
                var query = from c in db.Classes
                            where c.Season == season && c.Year == year
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            where course.Department == subject && course.Number == num
                            join cat in db.AssignmentCategories
                            on c.ClassId equals cat.InClass
                            where cat.Name == category
                            select cat.CategoryId;

                Assignments newAssign = new Assignments();
                newAssign.Category = query.FirstOrDefault();
                newAssign.Name = asgname;
                newAssign.Due = asgdue;
                newAssign.MaxPoints = (uint) asgpoints;
                newAssign.Contents = asgcontents;

                db.Assignments.Add(newAssign);

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
    /// Gets a JSON array of all the submissions to a certain assignment.
    /// Each object in the array should have the following fields:
    /// "fname" - first name
    /// "lname" - last name
    /// "uid" - user ID
    /// "time" - DateTime of the submission
    /// "score" - The score given to the submission
    /// 
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetSubmissionsToAssignment(string subject, int num, string season, int year, string category, string asgname)
    {
            using (var db = new Team103LMSContext())
            {
                var query = from c in db.Classes
                            where c.Season == season && c.Year == year
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            where course.Department == subject && course.Number == num
                            join cat in db.AssignmentCategories
                            on c.ClassId equals cat.InClass
                            join a in db.Assignments
                            on cat.CategoryId equals a.Category
                            join s in db.Submissions
                            on a.AssignmentId equals s.Assignment
                            where a.Name == asgname
                            join student in db.Students
                            on s.Student equals student.UId
                            select new
                            {
                                fname = a.Name,
                                lname = cat.Name,
                                uid = s.Student,
                                time = DateTime.Now,
                                score = s.Score,
                            };

                return Json(query.ToArray());
            }
        }


    /// <summary>
    /// Set the score of an assignment submission
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment</param>
    /// <param name="uid">The uid of the student who's submission is being graded</param>
    /// <param name="score">The new score for the submission</param>
    /// <returns>A JSON object containing success = true/false</returns>
    public IActionResult GradeSubmission(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
    { 

            using (var db = new Team103LMSContext())
            {
                var query = from c in db.Classes
                            where c.Season == season && c.Year == year
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            where course.Department == subject && course.Number == num
                            join cat in db.AssignmentCategories
                            on c.ClassId equals cat.InClass
                            join a in db.Assignments
                            on cat.CategoryId equals a.Category
                            join s in db.Submissions
                            on a.AssignmentId equals s.Assignment
                            where a.Name == asgname
                            join student in db.Students
                            on s.Student equals student.UId
                            select s;

                Submissions x = query.SingleOrDefault();
                if (x != null)
                    x.Score = (uint)score;

                try
                { db.SaveChanges(); }
                catch (DbUpdateException e)
                {
                    return Json(new { success = false });
                }
                CalculateStudentGrade();
                return Json(new { success = true });
            }
        
    }


    /// <summary>
    /// Returns a JSON array of the classes taught by the specified professor
    /// Each object in the array should have the following fields:
    /// "subject" - The subject abbreviation of the class (such as "CS")
    /// "number" - The course number (such as 5530)
    /// "name" - The course name
    /// "season" - The season part of the semester in which the class is taught
    /// "year" - The year part of the semester in which the class is taught
    /// </summary>
    /// <param name="uid">The professor's uid</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetMyClasses(string uid)
    {
            using (var db = new Team103LMSContext())
            {
                var query = from c in db.Classes
                            where c.TaughtBy == uid
                            join course in db.Courses
                            on c.Listing equals course.CatalogId
                            select new
                            {
                                subject = course.Department,
                                number = course.Number,
                                name = course.Name,
                                season = c.Season,
                                year = c.Year,
                            };
                return Json(query.ToArray());
            }
        }


        /*******End code to modify********/

        #region Helpers
        private string CalculateStudentGrade(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
    {
        {
                using (var db = new Team103LMSContext())
                {
                    var query = from c in db.Classes
                                where c.Season == season && c.Year == year
                                join course in db.Courses
                                on c.Listing equals course.CatalogId
                                where course.Department == subject && course.Number == num
                                join cat in db.AssignmentCategories
                                on c.ClassId equals cat.InClass
                                select cat;
                    double classPercent = 0.0;
                    double weightSum = 0;
                    foreach (var ac in query.ToArray())
                    {
                        var innerquery = from a in db.AssignmentCategories
                                         where ac.CategoryId == a.Category
                                         join assign in db.Assignments
                                         on a.CategoryID equals assign.Category
                                         select assign;
                        int maxCategoryPoints = 0;
                        int totalEarned = 0;
                        if (innerquery.Any())
                        {
                            foreach (var task in innerquery)
                            {
                                maxCategoryPoints += task.MaxPoints;
                                int maxSubmit = 0;
                                foreach (var submit in task.Submissions)
                                {
                                    if (submit.uID == uid)
                                    {
                                        if (submit.Score > maxSubmit)
                                        {
                                            maxSubmit = submit.Score;
                                        }
                                    }
                                }
                                totalEarned += maxSubmit;
                            }
                        }
                        double categoryPercent = totalEarned / maxCategoryPoints;
                        categoryPercent *= ac.Weight;
                        classPercent += categoryPercent;
                        weightSum += ac.Weight;
                    }
                    double scaleFactor = 100 / weightSum;
                    double grade = classPercent * scaleFactor;
                    string letterGrade;

                    if (grade >= 93.0)
                    {
                        letterGrade = "A";
                    }
                    else if (grade >= 90.0)
                    {
                        letterGrade = "A-";
                    }
                    else if (grade >= 87.0)
                    {
                        letterGrade = "B+";
                    }
                    else if (grade >= 83.0)
                    {
                        letterGrade = "B";
                    }
                    else if (grade >= 80.0)
                    {
                        letterGrade = "B-";
                    }
                    else if (grade >= 77.0)
                    {
                        letterGrade = "C+";
                    }
                    else if (grade >= 73.0)
                    {
                        letterGrade = "C";
                    }
                    else if (grade >= 70.0)
                    {
                        letterGrade = "C-";
                    }
                    else if (grade >= 67.0)
                    {
                        letterGrade = "D+";
                    }
                    else if (grade >= 63.0)
                    {
                        letterGrade = "D";
                    }
                    else if (grade >= 60.0)
                    {
                        letterGrade = "D-";
                    }
                    else
                    {
                        letterGrade = "E";
                    }


                }       
    


            }
        }

        #endregion
    }
}