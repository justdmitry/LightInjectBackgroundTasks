using LightInjectBackgroundTasks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            ViewBag.Now = someService.GetNow();
            return View();
        }
    }
}