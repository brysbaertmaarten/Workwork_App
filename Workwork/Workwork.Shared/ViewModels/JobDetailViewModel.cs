using MvvmCross.Core.ViewModels;
using Plugin.ExternalMaps;
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

        public void GetJobDetails(int jobId)
        {
            Job = _workService.GetJobById(jobId);
        }

        public async void LaunchMaps()
        {
            var success = await CrossExternalMaps.Current.NavigateTo(Job.Location.Street, Job.Location.Lat, Job.Location.Lon);
        }

        public MvxCommand LaunchMapsCommand
        {
            get
            {
                return new MvxCommand(() => LaunchMaps());
            }
        }
    }
}
