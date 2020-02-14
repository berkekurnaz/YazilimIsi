using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Portfolio
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string ProjectUrl { get; set; }
        public int? DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }
    }
}
