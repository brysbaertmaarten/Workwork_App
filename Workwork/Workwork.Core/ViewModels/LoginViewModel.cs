using MvvmCross.Core.ViewModels;
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


        public async void Login()
        {
            Account account = new Account();
            account = await _workService.GetAccount(Username, Password);

            if (account.Id != 0)
            {
                //ga naar volgende pagina
                ShowViewModel<JobViewModel>(account);
            }
            else
            {
                //foutmelding in lblErrorMessage
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


    }
}
