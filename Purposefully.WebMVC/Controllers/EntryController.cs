using Microsoft.AspNet.Identity;
using Purposefully.Models.EntryModels;
using Purposefully.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purposefully.WebMVC.Controllers
{
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EntryService(userId);
            var model = service.GetEntries();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEntryService();

            if (service.CreateEntry(model))
            {
                TempData["SaveResult"] = "Your entry was sucessfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created, please try again.");
            return View(model);
        }

        private EntryService CreateEntryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EntryService(userId);
            return service;
        }


    }
}