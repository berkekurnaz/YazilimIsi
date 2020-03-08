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
        User GetUserByName(string name);

        void Add(User user);
        void Update(User user);
        void Delete(User user);

        bool UserUsernameCheck(string username);
        bool UserMailCheck(string mail);

        bool UserLoginCheck(string username, string password);
    }
}
