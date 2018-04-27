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
            ContactInfo = new ContactInfo();
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
            //check input of ContactInfo
            if (true)
            {
                SaveData();
            }
        }

        private async void SaveData()
        {
            //get Job from textfile
            Job job = new Job();
            job = JsonConvert.DeserializeObject<Job>(ReadFromFile("Job"));

            //get Location from textfile
            Location loc = new Location();
            loc = JsonConvert.DeserializeObject<Location>(ReadFromFile("Location"));

            job.Location = loc;
            job.ContactInfo = ContactInfo;

            //post data
            Job result = await _workService.AddJob(job);

            //succesboodschap
            ShowViewModel<MyJobViewModel>();
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
