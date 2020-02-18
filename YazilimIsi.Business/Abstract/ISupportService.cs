using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface ISupportService
    {
        List<Support> GetAllSupports();
        List<Support> GetSupportsByUserId(int? userId);
        List<Support> GetSupportsByDeveloperId(int? developerId);

        Support GetSupportById(int Id);
        void Add(Support support);
        void Update(Support support);
        void Delete(Support support);
    }
}
