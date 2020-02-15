using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class SupportManager : ISupportService
    {

        private ISupportDal _supportDal;

        public SupportManager(ISupportDal supportDal)
        {
            _supportDal = supportDal;
        }

        public void Add(Support support)
        {
            _supportDal.Add(support);
        }

        public void Delete(Support support)
        {
            _supportDal.Delete(support);
        }

        public List<Support> GetAllSupports()
        {
            return _supportDal.GetAll();
        }

        public Support GetSupportById(int Id)
        {
            return _supportDal.Get(x => x.Id == Id);
        }

        public void Update(Support support)
        {
            _supportDal.Update(support);
        }
    }
}
