using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.WebApp.Models
{
    public class YazilimciViewModels
    {
        public Developer Developer { get; set; }
        public List<Offer> LastFiveOffers { get; set; }
        public List<Portfolio> LastFivePortfolio { get; set; }
        public List<string> DeveloperSkills { get; set; }
        public List<string> DeveloperAreas { get; set; }
        public List<Award> LastFiveAwards { get; set; }

        public Portfolio FormPortfolio { get; set; }
        public Award FormAward { get; set; }
        public Education FormEducation { get; set; }
    }
}
