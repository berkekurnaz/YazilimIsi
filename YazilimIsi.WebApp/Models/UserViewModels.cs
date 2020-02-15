using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.WebApp.Models
{
    public class UserViewModels
    {
        public User User { get; set; }
        public List<Job> UserJobs { get; set; }
    }
}
