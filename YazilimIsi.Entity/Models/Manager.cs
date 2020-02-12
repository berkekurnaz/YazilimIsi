using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Photo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
