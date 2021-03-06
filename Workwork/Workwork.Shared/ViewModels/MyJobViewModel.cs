﻿using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Functions.Models;
using Workwork.Shared;
using Xamarin.Forms;

namespace Workwork.Core.ViewModels
{
    public class MyJobViewModel : MvxViewModel
    {
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

        public IMvxCommand<int> RemoveItemCommand
        {
            get
            {
                return new MvxCommand<int>(RemoveItem);
            }
        }

        private async void RemoveItem(int index)
        {

            Job j = Jobs[index];
            //Jobs.RemoveAt(index);
            //RaisePropertyChanged(() => Jobs);
            await _workService.DeleteJob(j.Id);
            MessagingCenter.Send(this, "Delete");
            LoadJobs(Globals.AccountId);
        }
    }
}
