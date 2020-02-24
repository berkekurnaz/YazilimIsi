using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class AccountActivityManager : IAccountActivityService
    {

        private IAccountActivityDal _accountActivityDal;

        public AccountActivityManager(IAccountActivityDal accountActivityDal)
        {
            _accountActivityDal = accountActivityDal;
        }

        public void Add(AccountActivity accountActivity)
        {
            _accountActivityDal.Add(accountActivity);
        }

        public void Delete(AccountActivity accountActivity)
        {
            _accountActivityDal.Delete(accountActivity);
        }

        public AccountActivity GetAccountActivityById(int Id)
        {
            return _accountActivityDal.Get(x => x.Id == Id);
        }

        public List<AccountActivity> GetAllAccountActivities()
        {
            return _accountActivityDal.GetAll();
        }

        public List<AccountActivity> GetAllAccountActivitiesByDeveloperId(int developerId)
        {
            return _accountActivityDal.GetAll(x => x.DeveloperId == developerId);
        }

        public List<AccountActivity> GetAllAccountActivitiesByUserId(int userId)
        {
            return _accountActivityDal.GetAll(x => x.UserId == userId);
        }

        public void Update(AccountActivity accountActivity)
        {
            _accountActivityDal.Update(accountActivity);
        }
    }
}
