using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Functions.Models;
using Xamarin.Forms;

namespace Workwork.Core.ViewModels
{
    public class JobViewModel : MvxViewModel
    {
        private IWorkService _workService;

        public JobViewModel(IWorkService workService)
        {
            _workService = workService;
            LoadJobs();
            MessagingCenter.Subscribe<MyJobViewModel>(this, "Delete", (sender) =>
            {
                LoadJobs();
            });
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
    }
}
