using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
    public class JobsService
    {

        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal List<Job> GetAll()
        {
            List<Job> jobs = _repo.GetAll();
            return jobs;
        }

        internal Job Create(Job jobData)
        {
            Job newJob = _repo.Create(jobData);
            return newJob;
        }

        internal void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}