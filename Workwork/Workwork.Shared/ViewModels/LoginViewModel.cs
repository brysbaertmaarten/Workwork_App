using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Functions.Models;
using Workwork.Shared;
using Workwork.Shared.ViewModels;

namespace Workwork.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private IWorkService _workService;
        public LoginViewModel(IWorkService workService)
        {
            _workService = workService;
        }

        public void Init(Account account)
        {
            Username = account.UserName;
            Password = account.Password;
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                RaisePropertyChanged(() => Error);
            }
        }

        public bool Validate()
        {
            if (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Username)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async void Login()
        {
            if (Validate())
            {
                Account account = new Account();
                account = await _workService.GetAccount(Username, Password);

                if (account.Id != 0)
                {
                    Error = "";
                    //sla account id globaal op
                    Globals.AccountId = account.Id;
                    //ga naar volgende pagina
                    ShowViewModel<JobTabViewModel>(account);
                }
                else
                {
                    //foutmelding in lblErrorMessage
                    Error = "Username and password do not match";
                }
            }
            else
            {
                Error = "Username and password do not match";
            }
        }

        public MvxCommand LoginCommand
        {
            get
            {
                return new MvxCommand(() => Login());
            }
        }

        public MvxCommand RegisterCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<RegisterViewModel>());
            }
        }


    }
}
