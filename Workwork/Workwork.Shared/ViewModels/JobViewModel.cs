﻿using MvvmCross.Core.ViewModels;
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
        private IWorkService _workService;

        public JobViewModel(IWorkService workService)
        {
            _workService = workService;
            LoadJobs();
        }
        public JobViewModel()
        {

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

    }
}