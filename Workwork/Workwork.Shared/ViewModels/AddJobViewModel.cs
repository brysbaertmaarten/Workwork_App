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
using Workwork.Shared;

namespace Workwork.Core.ViewModels
{
    public class AddJobViewModel : MvxViewModel
    {
        private IMvxFileStore _fileStore;
        public AddJobViewModel(IMvxFileStore fileStore)
        {
            _fileStore = fileStore;
            Job = new Job
            {
                AccountId = Globals.AccountId
            };
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

        private void SaveToFile()
        {
            string _folderName = "NewJob";
            string _fileName = "Job";

            try
            {
                if (!_fileStore.FolderExists(_folderName)) _fileStore.EnsureFolderExists(_folderName);
                var json = JsonConvert.SerializeObject(Job);
                _fileStore.WriteFile(_folderName + "/" + _fileName, json);
            }
            catch (Exception ex)
            {
                throw ex;
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
                SaveToFile();
                ShowViewModel<AddLocationViewModel>();
            }
            else
            {
                //error message "alle velden invullen aub"
            }
        }


    }
}
