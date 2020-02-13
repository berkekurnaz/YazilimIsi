using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int Id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
