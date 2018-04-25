using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Functions.Models;

namespace Workwork.Core.ViewModels
{
    public class AddContactInfoViewModel : MvxViewModel
    {
        public AddContactInfoViewModel()
        {
            Job = new Job();    
        }

        public void Init(Job job, Location location)
        {
            Job = job;
        }

        private Job _job;

        public Job Job
        {
            get { return _job; }
            set { _job = value; }
        }
    }

    
}
