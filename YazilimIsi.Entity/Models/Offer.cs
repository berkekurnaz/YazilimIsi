using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Offer
    {
        public int Id { get; set; }
        public string Price { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? JobId { get; set; }
        public int? DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Job Job { get; set; }
    }
}
