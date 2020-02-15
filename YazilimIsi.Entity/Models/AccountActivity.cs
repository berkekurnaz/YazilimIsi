using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class AccountActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsIncrease { get; set; }
        public int? UserId { get; set; }
        public int? DeveloperId { get; set; }
        public string Money { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Job User { get; set; }
    }
}
