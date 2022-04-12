using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Assignments
    {
        public Assignments()
        {
            Submissions = new HashSet<Submissions>();
        }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int? Points { get; set; }
        public string Contents { get; set; }
        public DateTime? Due { get; set; }
        public int AssignId { get; set; }

        public virtual AssignmentCategories Category { get; set; }
        public virtual ICollection<Submissions> Submissions { get; set; }
    }
}
