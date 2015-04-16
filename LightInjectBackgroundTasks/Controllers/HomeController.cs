using LightInjectBackgroundTasks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LightInjectBackgroundTasks.Controllers
{
    public class HomeController : Controller
    {
        private SomeService someService;

        public HomeController(SomeService someService)
        {
            this.someService = someService;
        }

        public async Task<ActionResult> Index()
        {
            await Task.Run(() => Thread.Sleep(2000));
            ViewBag.Now = someService.GetNow();
            return View();
        }
    }
}