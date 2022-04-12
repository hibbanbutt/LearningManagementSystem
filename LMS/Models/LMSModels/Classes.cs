using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Classes
    {
        public Classes()
        {
            AssignmentCategories = new HashSet<AssignmentCategories>();
            Enrolled = new HashSet<Enrolled>();
        }

        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Location { get; set; }
        public int SemesterYear { get; set; }
        public string SemesterSeason { get; set; }
        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public string Teacher { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Professors TeacherNavigation { get; set; }
        public virtual ICollection<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual ICollection<Enrolled> Enrolled { get; set; }
    }
}
