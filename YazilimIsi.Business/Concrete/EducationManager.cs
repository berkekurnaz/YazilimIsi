using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class EducationManager : IEducationService
    {

        private IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public void Add(Education education)
        {
            _educationDal.Add(education);
        }

        public void Delete(Education education)
        {
            _educationDal.Delete(education);
        }

        public List<Education> GetAllEducations()
        {
            return _educationDal.GetAll();
        }

        public Education GetEducationById(int Id)
        {
            return _educationDal.Get(x => x.Id == Id, x => x.Developer);
        }

        public List<Education> GetEducationsByDeveloperId(int developerId)
        {
            return _educationDal.GetAll(x => x.DeveloperId == developerId, x => x.Developer);
        }

        public void Update(Education education)
        {
            _educationDal.Update(education);
        }

    }
}
