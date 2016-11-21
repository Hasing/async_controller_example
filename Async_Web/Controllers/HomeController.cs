using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Async_Web.Models;

namespace Async_Web.Controllers
{
    public class HomeController : AsyncController
    {
        private EmployeesRepository repository = new EmployeesRepository();

        #region Demo1

        //Error
        public ActionResult Demo1()
        {
            var task = repository.GetAllAsync();
            //other logic
            var employees = task.Result;

            return View("Index", employees);
        }

        #endregion

        #region Demo2

        public void Demo2Async()
        {
            AsyncManager.OutstandingOperations.Increment(1);
            Task.Run(() =>
            {
                var task = repository.GetAllAsync();
                AsyncManager.Parameters["employees"] = task.Result;
                AsyncManager.OutstandingOperations.Decrement();
            });
            //repository.GetAllAsync().ContinueWith(t =>
            //{
            //    AsyncManager.Parameters["employees"] = t.Result;
            //    AsyncManager.OutstandingOperations.Decrement();
            //});
        }

        public ActionResult Demo2Completed(List<Employee> employees)
        {
            return View("Index", employees);
        }

        #endregion

        #region Demo3

        public ActionResult Demo3()
        {
            var task = Task.Run(() => repository.GetAllAsync());

            //other logic

            return View("Index", task.Result);
        }

        #endregion

        #region Demo4

        public Task<ViewResult> Demo4()
        {
            return Task.Run(() =>
            {
                var task = repository.GetAllAsync();

                //other logic

                return View("Index", task.Result);
            });
        }

        #endregion

        #region Demo5

        public async Task<ActionResult> Demo5()
        {
            var task = repository.GetAllAsync();

            //other logic

            return View("Index", await task);
        }

        #endregion
    }
}