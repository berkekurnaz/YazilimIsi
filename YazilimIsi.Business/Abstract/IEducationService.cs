using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IEducationService
    {
        List<Education> GetAllEducations();
        List<Education> GetEducationsByDeveloperId(int developerId);

        Education GetEducationById(int Id);
        void Add(Education education);
        void Update(Education education);
        void Delete(Education education);
    }
}
