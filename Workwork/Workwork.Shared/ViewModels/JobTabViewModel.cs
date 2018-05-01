using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Core.ViewModels;

namespace Workwork.Shared.ViewModels
{
    public class JobTabViewModel : MvxViewModel
    {
        private readonly IWorkService _workService;

        private readonly Lazy<JobViewModel> _jobViewModel;
        public JobViewModel JobVM => _jobViewModel.Value;

        private readonly Lazy<MyJobViewModel> _myJobViewModel;
        public MyJobViewModel MyJobVM => _myJobViewModel.Value;

        public JobTabViewModel(IWorkService workService)
        {
            this._workService = workService;
            _jobViewModel = new Lazy<JobViewModel>(Mvx.IocConstruct<JobViewModel>);
            _myJobViewModel = new Lazy<MyJobViewModel>(Mvx.IocConstruct<MyJobViewModel>);
        }

        public MvxCommand NavigateToAddJobCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<AddJobViewModel>());
            }
        }
    }
}
