using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using Newtonsoft.Json;
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
        private IMvxFileStore _fileStore;
        public AddLocationViewModel(IMvxFileStore fileStore)
        {
            _fileStore = fileStore;
            Location = new Location();
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

        private void SaveToFile()
        {
            string _folderName = "NewJob";
            string _fileName = "Location";

            try
            {
                if (!_fileStore.FolderExists(_folderName)) _fileStore.EnsureFolderExists(_folderName);
                var json = JsonConvert.SerializeObject(Location);
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
            if (!string.IsNullOrWhiteSpace(Location.City) || !string.IsNullOrWhiteSpace(Location.Country) || !string.IsNullOrWhiteSpace(Location.Number))
            {
                ShowViewModel<AddContactInfoViewModel>();
                SaveToFile();
            }
            else
            {
                //error message "alle velden invullen aub"
            }
        }
    }
}
