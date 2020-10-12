using Microsoft.AspNet.Identity;
using Purposefully.Models.ProfileModels;
using Purposefully.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purposefully.WebMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            var model = service.GetProfiles();
            return View(model);
        }

        // GET 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProfileService();

            if (service.CreateProfile(model))
            {
                TempData["SaveResult"] = "Your profile was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Profile could not be created, please try again.");
            return View(model);
        }

        // Get individual/detail
        public ActionResult Details(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileById(id);

            return View(model);
        }

        // Update - Edit the profile
        public ActionResult Edit(int id)
        {
            var service = CreateProfileService();
            var detail = service.GetProfileById(id);
            var model =
                new ProfileEdit
                {
                    ProfileId = detail.ProfileId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Motivation = detail.Motivation
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProfileEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProfileId != id)
            {
                ModelState.AddModelError("", "ID does not match one in the database, please try again.");
                return View(model);
            }

            var service = CreateProfileService();

            if (service.UpdateProfile(model))
            {
                TempData["SaveResult"] = "Your profile was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated, please try again.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileById(id);
            return View(model);
        }
        // Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProfile(int id)
        {
            var service = CreateProfileService();

            service.DeleteProfile(id);

            TempData["SaveResult"] = "Your profile was deleted successfully.";

            return RedirectToAction("Index");
        }

        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            return service;
        }
    }
}