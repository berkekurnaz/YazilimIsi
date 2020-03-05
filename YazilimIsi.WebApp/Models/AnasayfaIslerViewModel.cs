using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.WebApp.Models
{
    public class AnasayfaIslerViewModel
    {
        public Offer Offer { get; set; }
        public List<Job> Jobs { get; set; }
        public Job Job { get; set; }
        public Developer Developer { get; set; } // For Developer Login Check
        public Offer DeveloperOffer { get; set; } // For Developer Offer Check
        public IPagingList MyPagingModel { get; set; }
    }
}
