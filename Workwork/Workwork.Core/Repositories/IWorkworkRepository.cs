using System.Collections.Generic;
using System.Threading.Tasks;
using Workwork.Functions.Models;

namespace Workwork.Core.Repositories
{
    public interface IWorkworkRepository
    {
        Task<Account> AddAccount(Account newAccount);
        Task<Job> AddJob(NewJob newJob);
        Task<Account> GetAccount(string userName, string pw);
        Task<List<Job>> GetAllJobs();
        Task<List<Job>> GetJobsByAccountId(int accountId);
        Task<Job> UpdateJob(Job job);
        Task<bool> UserNameExists(string userName);
    }
}