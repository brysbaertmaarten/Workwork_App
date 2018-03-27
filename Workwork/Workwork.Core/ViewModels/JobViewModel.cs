using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Functions.Models;

namespace Workwork.Core.ViewModels
{
    public class JobViewModel : MvxViewModel
    {
        private WorkService _workService;

        public JobViewModel(WorkService workService)
        {
            _workService = workService;
            LoadJobs();
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

        private async void LoadJobs()
        {
            Jobs = await _workService.GetAllJobs();
        }

    }
}
