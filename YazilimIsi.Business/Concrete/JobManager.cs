using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class JobManager : IJobService
    {

        private IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public void Add(Job job)
        {
            _jobDal.Add(job);
        }

        public void Delete(Job job)
        {
            _jobDal.Delete(job);
        }

        public List<Job> GetAllJobs()
        {
            return _jobDal.GetAll();
        }

        public Job GetJobById(int Id)
        {
            return _jobDal.Get(x => x.Id == Id);
        }

        public List<Job> GetJobsByUserId(int userId)
        {
            return _jobDal.GetAll(x => x.UserId == userId);
        }

        public void Update(Job job)
        {
            _jobDal.Update(job);
        }
    }
}
