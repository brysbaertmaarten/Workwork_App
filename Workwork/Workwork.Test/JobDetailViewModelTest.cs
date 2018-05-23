using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Base;
using MvvmCross.Core;
using MvvmCross.Tests;
using MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Workwork.Core.Services;
using Workwork.Core.ViewModels;
using Workwork.Functions.Models;

namespace Workwork.Test
{
    [TestClass]
    public class JobDetailViewModelTest : MvxIoCSupportingTest
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
        public void Job_Property_Return_Job()
        {
            //Job job = new Job()
            //{
            //    Id = 1,
            //    Title = "test",
            //    Description = "description",
            //    Payment = "payment",
            //    PostTime = DateTime.Now,
            //    IsDone = false,
            //    AccountId = 1
            //};

            //var mockWorkService = new Mock<IWorkService>();
            //mockWorkService.Setup(ws => ws.GetJobById(1)).Returns(job);

            //var vm = new JobDetailViewModel(mockWorkService.Object);
            ////vm.Init(job);

            //var Job = vm.Job;

            //Assert.IsNotNull(Job);
        }
    }
}
