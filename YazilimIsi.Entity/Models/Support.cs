using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Support
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsCompleted { get; set; }
        public string Username { get; set; }
        public string SupportFile { get; set; }
    }
}
