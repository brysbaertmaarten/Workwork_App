using System.Collections.Generic;
using System.Threading.Tasks;
using Workwork.Functions.Models;

namespace Workwork.Core.Services
{
    public interface IWorkService
    {
        Task<Account> AddAccount(Account account);
        Task<Job> AddJob(Job job);
        Task<Account> GetAccount(string userName, string pw);
        Task<List<Job>> GetAllJobs();
        Task<List<Job>> GetJobsByAccountId(int id);
        Task<bool> SetJobDone(int id);
        Task<bool> UserNameExists(string un);
    }
}