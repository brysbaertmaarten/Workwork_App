using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Repositories;
using Workwork.Functions.Models;

namespace Workwork.Core.Services
{
    public class WorkService : IWorkService
    {
        private IWorkworkRepository _workRepo;

        public WorkService(IWorkworkRepository workRepo)
        {
            _workRepo = workRepo;
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _workRepo.GetAllJobs();
        }

        public async Task<List<Job>> GetJobsByAccountId(int id)
        {
            return await _workRepo.GetJobsByAccountId(id);
        }

        public async Task<Account> AddAccount(Account account)
        {
            return await _workRepo.AddAccount(account);
        }

        public async Task<bool> UserNameExists(string un)
        {
            return await _workRepo.UserNameExists(un);
        }

        public async Task<Account> GetAccount(string userName, string pw)
        {
            return await _workRepo.GetAccount(userName, pw);
        }

        public async Task<Job> AddJob(Job job)
        {
            return await _workRepo.AddJob(job);
        }

        public async Task<bool> SetJobDone(int id)
        {
            Job job = new Job();
            job.Id = id;
            job.IsDone = true;
            return await _workRepo.UpdateJob(job);
        }
    }
}
