using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Submissions
    {
        public int? Score { get; set; }
        public DateTime? SubmitTime { get; set; }
        public string Contents { get; set; }
        public int AssignId { get; set; }
        public string UId { get; set; }
        public int SubmitId { get; set; }

        public virtual Assignments Assign { get; set; }
        public virtual Students U { get; set; }
    }
}
