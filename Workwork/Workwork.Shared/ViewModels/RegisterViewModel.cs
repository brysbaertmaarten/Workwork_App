using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Functions.Models;

namespace Workwork.Core.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        private IWorkService _workService;
        public RegisterViewModel(IWorkService workService)
        {
            _workService = workService;
            _account = new Account();
        }

        private Account _account;
        public Account Account
        {
            get { return _account; }
            set
            {
                _account = value;
                RaisePropertyChanged(() => Account);
            }
        }

        private string _repeatPassword;
        public string RepeatPassword
        {
            get { return _repeatPassword; }
            set
            {
                _repeatPassword = value;
                RaisePropertyChanged(() => RepeatPassword);
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


        public bool CheckPasswords()
        {
            if (!string.IsNullOrWhiteSpace(Account.Password))
            {
                if (Account.Password == RepeatPassword)
                {
                    return true;
                }
                else
                {
                    Error = "Passwords do not match";
                    //kleur veld rood en error bericht (Passwords do not match)
                    return false;
                }
            }
            else
            {
                Error = "Password is not valid";
                return false;
            }
        }

        public async Task<bool> CheckUsername()
        {
            if (!string.IsNullOrWhiteSpace(Account.UserName))
            {
                if (await _workService.UserNameExists(Account.UserName))
                {
                    Error = "Username already exist";
                    //kleur veld rood en error bericht (Username already exist)
                    return false;
                }
                else
                {
                    //kleur veld terug zwart
                    Error = "";
                    return true;
                }
            }
            else
            {
                Error = "Username can not be empty";
                return false;
            }
        }

        public async Task<bool> CheckIfInputIsValid()
        {
            //check of alle velden zijn ingevuld en juist zijn ingevuld.

            if (string.IsNullOrWhiteSpace(Account.FirstName))
            {
                Error = "First name can not be empty";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Account.LastName))
            {
                Error = "Last name can not be empty";
                return false;
            }

            if (!await CheckUsername())
            {
                return false;
            }

            if (!CheckPasswords())
            {
                return false;
            }

            Error = "";
            return true;
        }

        public async void CreateAccount()
        {
            //wordt alleen uitgevoerd als alle waarden zijn ingevuld en kloppen
            if (await CheckIfInputIsValid())
            {
                await _workService.AddAccount(Account);
                ShowViewModel<LoginViewModel>(Account);
            }
        }

        public MvxCommand AddAccount
        {
            get
            {
                return new MvxCommand(() => CreateAccount());
            }
        }

        public MvxCommand LoginCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LoginViewModel>());
            }
        }


    }
}
