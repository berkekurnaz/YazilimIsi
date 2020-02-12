using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ViewCount { get; set; }
        public int? UserId { get; set; }
        public int? DeveloperId { get; set; }
        public bool? IsConfirm { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Developer Developer { get; set; }
        public User User { get; set; }
    }
}
