using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Functions.Models;

namespace Workwork.Core.ViewModels
{
    public class AddLocationViewModel : MvxViewModel
    {
        public AddLocationViewModel()
        {
            Location = new Location();
        }

        public void Init(Job job)
        {
            job.Location = Location;
            Job = job;
        }

        private Location _locaction;

        public Location Location
        {
            get { return _locaction; }
            set
            {
                _locaction = value;
                RaisePropertyChanged(() => Location);
            }
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

        public MvxCommand Next
        {
            get
            {
                return new MvxCommand(() => ValidateInput());
            }
        }

        public void ValidateInput()
        {
            if (!string.IsNullOrWhiteSpace(Location.City) || !string.IsNullOrWhiteSpace(Location.Country) || !string.IsNullOrWhiteSpace(Location.Number))
            {
                ShowViewModel<AddContactInfoViewModel>(Location);
            }
            else
            {
                //error message "alle velden invullen aub"
            }
        }
    }
}
