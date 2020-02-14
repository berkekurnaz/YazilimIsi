using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Education
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }
    }
}
