using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class User
    {
        public User()
        {
            JobNavigation = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Money { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsConfirm { get; set; }

        public virtual ICollection<Job> JobNavigation { get; set; }
    }
}
