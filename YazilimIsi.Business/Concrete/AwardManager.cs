using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class AwardManager : IAwardService
    {

        private IAwardDal _awardDal;

        public AwardManager(IAwardDal awardDal)
        {
            _awardDal = awardDal;
        }

        public void Add(Award award)
        {
            _awardDal.Add(award);
        }

        public void Delete(Award award)
        {
            _awardDal.Delete(award);
        }

        public List<Award> GetAllAwards()
        {
            return _awardDal.GetAll();
        }

        public Award GetAwardById(int Id)
        {
            return _awardDal.Get(x => x.Id == Id);
        }

        public List<Award> GetAwardsByDeveloperId(int developerId)
        {
            return _awardDal.GetAll(x => x.DeveloperId == developerId);
        }

        public void Update(Award award)
        {
            _awardDal.Update(award);
        }

    }
}
