using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsRead { get; set; }
    }
}
