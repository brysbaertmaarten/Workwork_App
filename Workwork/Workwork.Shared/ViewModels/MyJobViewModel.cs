using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Functions.Models;
using Workwork.Shared;

namespace Workwork.Core.ViewModels
{
    public class MyJobViewModel : MvxViewModel
    {
        static int AccountId;

        private IWorkService _workService;
        public MyJobViewModel(IWorkService workService)
        {
            _workService = workService;
            LoadJobs(Globals.AccountId);
        }

        List<Job> _jobs;

        public List<Job> Jobs
        {
            get { return _jobs; }
            set
            {
                _jobs = value;
                RaisePropertyChanged(() => Jobs);
            }
        }

        private async void LoadJobs(int accountId)
        {
            Jobs = await _workService.GetJobsByAccountId(accountId);
            List<Job> jobs = Jobs;
            RaisePropertyChanged(() => Jobs);
        }

        public MvxCommand<Job> NavigateToDetailCommand
        {
            get
            {
                return new MvxCommand<Job>(
                    selectedJob =>
                    {
                        ShowViewModel<JobDetailViewModel>(selectedJob);
                    }
                );
            }
        }

        public IMvxCommand<int> RemoveWineCommand
        {
            get
            {
                return new MvxCommand<int>(RemoveWine);
            }
        }

        private void RemoveWine(int index)
        {
            int jobId = Jobs[index].Id;
            Jobs.RemoveAt(index);
            _workService.DeleteJob(jobId);
            LoadJobs(AccountId);
        }
    }
}
