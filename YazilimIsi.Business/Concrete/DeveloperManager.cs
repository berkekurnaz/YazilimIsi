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

        /* Yazilimci Giris Islemi */
        public bool DeveloperLoginCheck(string username, string password)
        {
            bool loginSuccess = true;
            var developer = _developerDal.GetAll(x => x.Username == username && x.Password == password).Count;
            if (developer == 0)
            {
                loginSuccess = false;
            }
            return loginSuccess;
        }

        /* Ayni Mail Adresi Kullanip Kullanmadigini Ogrenme */
        public bool DeveloperMailCheck(string mail)
        {
            bool state = true; // True olarak donerse durum temiz, mail kullanilmiyor.
            var developersCount = _developerDal.GetAll(x => x.Mail == mail).Count;
            if (developersCount > 0)
            {
                state = false;
            }
            return state;
        }

        /* Ayni Kullanici Adini Kullanip Kullanmadigini Ogrenme */
        public bool DeveloperUsernameCheck(string username)
        {
            bool state = true; // True olarak donerse durum temiz, mail kullanilmiyor.
            var developersCount = _developerDal.GetAll(x => x.Username == username).Count;
            if (developersCount > 0)
            {
                state = false;
            }
            return state;
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
