using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IAwardService
    {
        List<Award> GetAllAwards();
        List<Award> GetAwardsByDeveloperId(int developerId);

        Award GetAwardById(int Id);
        void Add(Award award);
        void Update(Award award);
        void Delete(Award award);
    }
}
