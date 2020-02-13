using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class DeveloperManager : IDeveloperService
    {

        private IDeveloperDal _developerDal;

        public DeveloperManager(IDeveloperDal developerDal)
        {
            _developerDal = developerDal;
        }

        /* Yeni Bir Yazilimci Ekleme */
        public void Add(Developer developer)
        {
            _developerDal.Add(developer);
        }

        /* Bir Yazilimci Silme */
        public void Delete(Developer developer)
        {
            _developerDal.Delete(developer);
        }

        /* Butun Yazilimcilari Getirme */
        public List<Developer> GetAllDevelopers()
        {
            return _developerDal.GetAll();
        }

        /* Bir Yazilimci Getirme */
        public Developer GetDeveloperById(int Id)
        {
            return _developerDal.Get(x => x.Id == Id);
        }

        /* Bir Yazilimci Guncelleme */
        public void Update(Developer developer)
        {
            _developerDal.Update(developer);
        }
    }
}
