using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class UserManager : IUserService
    {

        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        /* Yeni Bir Kullanici Ekleme */
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        /* Bir Kullanici Silme */
        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        /* Butun Kullanicilari Getirme */
        public List<User> GetAllUsers()
        {
            return _userDal.GetAll();
        }

        /* Bir Kullanici Getirme */
        public User GetUserById(int Id)
        {
            return _userDal.Get(x => x.Id == Id);
        }

        /* Bir Kullanici Guncelleme */
        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public bool UserLoginCheck(string username, string password)
        {
            bool loginSuccess = true;
            var user = _userDal.GetAll(x => x.Username == username && x.Password == password).Count;
            if (user == 0)
            {
                loginSuccess = false;
            }
            return loginSuccess;
        }

        public bool UserMailCheck(string mail)
        {
            bool state = true; // True olarak donerse durum temiz, mail kullanilmiyor.
            var usersCount = _userDal.GetAll(x => x.Mail == mail).Count;
            if (usersCount > 0)
            {
                state = false;
            }
            return state;
        }

        public bool UserUsernameCheck(string username)
        {
            bool state = true; // True olarak donerse durum temiz, mail kullanilmiyor.
            var usersCount = _userDal.GetAll(x => x.Username == username).Count;
            if (usersCount > 0)
            {
                state = false;
            }
            return state;
        }
    }
}
