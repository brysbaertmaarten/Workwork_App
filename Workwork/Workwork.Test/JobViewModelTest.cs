using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Base;
using MvvmCross.Commands;
using MvvmCross.Core;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Core.ViewModels;
using Workwork.Functions.Models;

namespace Workwork.Test
{
    [TestClass]
    public class JobViewModelTest : MvxIoCSupportingTest
    {
        protected MockDispatcher MockDispatcher;

        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
        }

        [TestMethod]
        public void Jobs_Property_Return_All_Jobs()
        {
            var jobs = new List<Job>();
            jobs.Add(new Job() {
                Id = 1,
                Title = "test",
                Description = "description",
                Payment = "payment",
                PostTime = DateTime.Now,
                IsDone = false,
                AccountId = 1
            });
            jobs.Add(new Job()
            {
                Id = 2,
                Title = "test",
                Description = "description",
                Payment = "payment",
                PostTime = DateTime.Now,
                IsDone = false,
                AccountId = 1
            });

            var mockWorkService = new Mock<IWorkService>();
            mockWorkService.Setup(ws => ws.GetAllJobs()).Returns(Task.FromResult(jobs));

            var vm = new JobViewModel(mockWorkService.Object);

            var allJobs = vm.Jobs;

            Assert.IsNotNull(allJobs);
            Assert.IsTrue(allJobs.Count == 2);
        }

        [TestMethod]
        public void NavigateToDetailCommand_Return_JobDetailViewModel()
        {
            //var navService = new Mock<IMvxNavigationService>();
            //navService.Verify(nav => nav.Navigate<JobDetailViewModel>(null), Times.Once());
        }
    }
}
