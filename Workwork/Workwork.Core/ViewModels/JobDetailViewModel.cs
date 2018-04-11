using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Functions.Models;

namespace Workwork.Core.ViewModels
{
    public class JobDetailViewModel : MvxViewModel
    {
        public JobDetailViewModel()
        {

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
            Job = job;
            Job jobb = job;
        }
    }
}
