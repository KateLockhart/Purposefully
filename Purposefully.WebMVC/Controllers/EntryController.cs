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
        public object UtcTime { get; private set; }

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

        // Get EntryDetails
        public ActionResult Details(int id)
        {
            var svc = CreateEntryService();
            var model = svc.GetEntryById(id);

            return View(model);
        }

        // Update - Edit the Entry 
        public ActionResult Edit(int id)
        {
            var service = CreateEntryService();
            var detail = service.GetEntryById(id);
            var model =
                new EntryEdit
                {
                    EntryId = detail.EntryId,
                    EntryTitle = detail.EntryTitle,
                    EntryContent = detail.EntryContent,
                    ForGoal = detail.ForGoal,
                    GoalId = detail.GoalId,
                    ModifiedUtc = DateTime.UtcNow
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EntryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EntryId != id)
            {
                ModelState.AddModelError("", "We're sorry, this doesn't match an ID in our system.");
                return View(model);
            }

            var service = CreateEntryService();

            if (service.UpdateEntry(model))
            {
                TempData["SaveResult"] = "Your journal entry has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated, please give it another try.");
            return View(model);
        }

        // Delete - Delete Entry
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEntryService();
            var model = svc.GetEntryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEntry(int id)
        {
            var service = CreateEntryService();

            service.DeleteEntry(id);

            TempData["SaveResult"] = "Your journal entry has successfully been deleted.";

            return RedirectToAction("Index");
        }

        private EntryService CreateEntryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EntryService(userId);
            return service;
        }   
    }
}