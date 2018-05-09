using System.Collections.Generic;
using System.Threading.Tasks;
using Workwork.Functions.Models;

namespace Workwork.Core.Repositories
{
    public interface IWorkworkRepository
    {
        Task<Account> AddAccount(Account newAccount);
        Task<Job> AddJob(Job newJob);
        Task<Account> GetAccount(string userName, string pw);
        Task<List<Job>> GetAllJobs();
        Job GetJobById(int jobId);
        Task<List<Job>> GetJobsByAccountId(int accountId);
        Task<bool> UpdateJob(Job job);
        Task<bool> UserNameExists(string userName);
        Task DeleteJob(int jobId);
    }
}