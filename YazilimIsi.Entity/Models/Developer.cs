using System;
using System.Collections.Generic;

namespace YazilimIsi.Entity.Models
{
    public partial class Developer
    {
        public Developer()
        {
            Award = new HashSet<Award>();
            Education = new HashSet<Education>();
            JobNavigation = new HashSet<Job>();
            Offer = new HashSet<Offer>();
            Portfolio = new HashSet<Portfolio>();
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
        public string MediaWebsite { get; set; }
        public string MediaGithub { get; set; }
        public string MediaLinkedin { get; set; }
        public string MediaMedium { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsConfirm { get; set; }
        public string Money { get; set; }
        public string DeveloperAreas { get; set; }
        public string DeveloperSkills { get; set; }

        public virtual ICollection<Award> Award { get; set; }
        public virtual ICollection<Education> Education { get; set; }
        public virtual ICollection<Job> JobNavigation { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<Portfolio> Portfolio { get; set; }
    }
}
