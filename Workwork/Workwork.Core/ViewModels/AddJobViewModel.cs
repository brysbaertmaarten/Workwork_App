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
    public class AddJobViewModel : MvxViewModel
    {
        public AddJobViewModel()
        {
            Job = new Job();
            Job.AccountId = 2;
        }

        //public void Init(Account account)
        //{
        //    Job.AccountId = account.Id;
        //}

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

        public MvxCommand Next
        {
            get
            {
                return new MvxCommand(() => ValidateInput());
            }
        }

        public void ValidateInput()
        {
            if (!string.IsNullOrWhiteSpace(Job.Title) || !string.IsNullOrWhiteSpace(Job.Description) || !string.IsNullOrWhiteSpace(Job.Payment))
            {
                //data wegscrhijven naar file
                ShowViewModel<AddLocationViewModel>();
            }
            else
            {
                //error message "alle velden invullen aub"
            }
        }


    }
}
