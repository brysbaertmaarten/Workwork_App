using Newtonsoft.Json;
using NMCT.Resto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Functions.Models;

namespace Workwork.Core.Repositories
{
    public class WorkworkRepository : BaseRepository, IWorkworkRepository
    {
        private const string _BASEURL = "https://workworkapi.azurewebsites.net/api/";

        public Task<List<Job>> GetAllJobs()
        {
            string url = String.Format("{0}GetAllJobs", _BASEURL);
            return GetAsync<List<Job>>(url);
        }

        public Task<List<Job>> GetJobsByAccountId(int accountId)
        {
            string url = String.Format("{0}GetJobsByAccountId/{1}", _BASEURL, accountId);
            return GetAsync<List<Job>>(url);
        }

        public Task<Job> AddJob(NewJob newJob)
        {
            string url = String.Format("{0}addJob", _BASEURL);
            return PostAsync<Job>(url, newJob);
        }

        public Task<Job> UpdateJob(Job job)
        {
            string url = String.Format("{0}UpdateJob", _BASEURL);
            return PostAsync<Job>(url, job);
        }

        public Task<bool> UserNameExists(string userName)
        {
            string url = String.Format("{0}UserNameExists/{1}", _BASEURL, userName);
            return GetAsync<bool>(url);
        }

        public Task<Account> GetAccount(string userName, string pw)
        {
            string url = String.Format("{0}GetAccount/{1}/{2}", _BASEURL, userName, pw);
            return GetAsync<Account>(url);
        }

        public Task<Account> AddAccount(Account newAccount)
        {
            string url = String.Format("{0}addAccount", _BASEURL);
            return PostAsync<Account>(url, newAccount);
        }
    }
}
