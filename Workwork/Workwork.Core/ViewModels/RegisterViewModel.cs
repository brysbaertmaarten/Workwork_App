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
                CheckIfUsernameExists();
            }
        }

        private bool _usernameExists;
        public bool UsernameExists
        {
            get
            {
                if (Account.UserName == null)
                {
                    return false;
                }
                return _usernameExists;
            }
            set
            {
                _usernameExists = value;
            }
        }

        private bool _passwordsMatch;

        public bool PasswordsMatch
        {
            get
            {
                if (Account.Password == null)
                {
                    return true;
                }
                return _passwordsMatch;
            }
            set { _passwordsMatch = value; }
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

        public void CheckPasswords()
        {
            if (Account.Password != null)
            {
                if (Account.Password == RepeatPassword)
                {
                    PasswordsMatch = true;
                }
                else
                {
                    PasswordsMatch = false;
                }
            }
        }

        public async void CheckIfUsernameExists()
        {
            if (Account.UserName != null)
            {
                UsernameExists = await _workService.UserNameExists(Account.UserName);
            }
        }

        public void CreateAccount()
        {   
            //to do: checked of velden zijn ingevuld
            if (true)
            {
                _workService.AddAccount(Account);
            }
        }

        public MvxCommand AddAccount
        {
            get
            {
                return new MvxCommand(() => CreateAccount());
            }
        }

    }
}
