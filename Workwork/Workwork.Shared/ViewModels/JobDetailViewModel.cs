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
    public class JobDetailViewModel : MvxViewModel
    {
        private IWorkService _workService;
        public JobDetailViewModel(IWorkService workService)
        {
            _workService = workService;
        }

        private Job _job;

        public Job Job
        {
            get { return _job; }
            set
            {
                _job = value;
                RaisePropertyChanged(() => Job);
            }
        }

        public void Init(Job job)
        {
            GetJobDetails(job.Id);
        }

        public async void GetJobDetails(int jobId)
        {
            Job = await _workService.GetJobById(jobId);
        }
    }
}
