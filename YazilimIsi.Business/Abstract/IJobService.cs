using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IJobService
    {
        List<Job> GetAllJobs();
        Job GetJobById(int Id);
        void Add(Job job);
        void Update(Job job);
        void Delete(Job job);
    }
}
