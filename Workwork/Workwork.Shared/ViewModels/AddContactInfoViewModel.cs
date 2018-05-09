using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Functions.Models;
using Workwork.Shared.ViewModels;

namespace Workwork.Core.ViewModels
{
    public class AddContactInfoViewModel : MvxViewModel
    {
        private IMvxFileStore _fileStore;
        private IWorkService _workService;
        public AddContactInfoViewModel(IMvxFileStore fileStore, IWorkService workService)
        {
            _fileStore = fileStore;
            _workService = workService;
            GetLocationFromTextFile();
            ContactInfo = new ContactInfo();
        }

        public void GetLocationFromTextFile()
        {
            Location = JsonConvert.DeserializeObject<Location>(ReadFromFile("Location")); //get Location from textfile
        }

        private Location _location;
        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                RaisePropertyChanged(() => Location);
            }
        }


        private ContactInfo _contactInfo;
        public ContactInfo ContactInfo
        {
            get { return _contactInfo; }
            set
            {
                _contactInfo = value;
                RaisePropertyChanged(() => ContactInfo);
            }
        }

        public MvxCommand Save
        {
            get
            {
                return new MvxCommand(() => ValidateInput());
            }
        }

        private void ValidateInput()
        {
            //TO DO check input of ContactInfo
            if (true)
            {
                SaveData();
            }
        }

        private async void SaveData()
        {
            Job job = new Job();
            job = JsonConvert.DeserializeObject<Job>(ReadFromFile("Job")); //get Job from textfile

            job.Location = Location;
            job.ContactInfo = ContactInfo;

            Job result = await _workService.AddJob(job); //post data

            //succesboodschap
            ShowViewModel<JobTabViewModel>(); //doorsturen naar MyJobTabViewModel
        }

        private string ReadFromFile(string _fileName)
        {
            string _folderName = "NewJob";
            try
            {
                string contents = string.Empty;
                _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out contents);
                return contents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
