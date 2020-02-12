using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Tags { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
