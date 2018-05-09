﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //GetPosition();
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

        // gekopïeerde code om locatie te krijgen.
        //public async void GetPosition()
        //{
        //    Position position = null;
        //    try
        //    {
        //        var locator = CrossGeolocator.Current;
        //        locator.DesiredAccuracy = 100;

        //        position = await locator.GetLastKnownLocationAsync();

        //        if (position == null)
        //        {
        //            position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
        //        };

        //        Location.Lat = position.Latitude;
        //        Location.Lon = position.Longitude;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Unable to get location: " + ex);
        //    }
        //}

        public MvxCommand Next
        {
            get
            {
                return new MvxCommand(() => ValidateInput());
            }
        }

        public async void ValidateInput()
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
