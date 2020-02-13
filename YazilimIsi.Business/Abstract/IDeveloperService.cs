using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IDeveloperService
    {
        List<Developer> GetAllDevelopers();
        Developer GetDeveloperById(int Id);
        void Add(Developer developer);
        void Update(Developer developer);
        void Delete(Developer developer);

        bool DeveloperUsernameCheck(string username);
        bool DeveloperMailCheck(string mail);

        bool DeveloperLoginCheck(string username, string password);
    }
}
