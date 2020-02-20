using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IAccountActivityService
    {
        List<AccountActivity> GetAllAccountActivities();
        List<AccountActivity> GetAllAccountActivitiesByUserId(int userId);

        AccountActivity GetAccountActivityById(int Id);
        void Add(AccountActivity accountActivity);
        void Update(AccountActivity accountActivity);
        void Delete(AccountActivity accountActivity);
    }
}
