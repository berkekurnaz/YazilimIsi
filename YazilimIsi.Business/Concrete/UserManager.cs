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
    }
}
