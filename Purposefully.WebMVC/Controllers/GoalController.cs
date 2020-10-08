using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purposefully.WebMVC.Controllers
{
    public class GoalController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            return View();
        }
    }
}