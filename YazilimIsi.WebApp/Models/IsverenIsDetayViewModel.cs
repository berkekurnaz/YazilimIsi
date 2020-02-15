using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.WebApp.Models
{
    public class IsverenIsDetayViewModel
    {
        public Job Job { get; set; }
        public User User { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
