using Microsoft.AspNet.Identity;
using Purposefully.Models.GoalModels;
using Purposefully.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purposefully.WebMVC.Controllers
{
    public class GoalController : Controller
    {
        public object UtcTime { get; private set; }

        // GET: Goal
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalService(userId);
            var model = service.GetGoals();
            return View(model);
        }

        // GET:
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GoalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGoalService();

            if (service.CreateGoal(model))
            {
                TempData["SaveResult"] = "Your goal was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "We're sorry, your goal could not be created. Please try again.");
            return View(model);
        }

        // Get: individual goal
        public ActionResult Details(int id)
        {
            var svc = CreateGoalService();
            var model = svc.GetGoalById(id);

            return View(model);
        }

        // Edit: Edit the goal
        public ActionResult Edit(int id)
        {
            var service = CreateGoalService();
            var detail = service.GetGoalById(id);
            var model =
                new GoalEdit
                {
                    GoalId = detail.GoalId,
                    GoalTitle = detail.GoalTitle,
                    GoalContent = detail.GoalContent,
                    GoalType = detail.GoalType,
                    Difficulty = detail.Difficulty,
                    StartDate = detail.StartDate,
                    EndDate = detail.EndDate,
                    Completed = detail.Completed
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GoalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GoalId != id)
            {
                ModelState.AddModelError("", "We're sorry, this doesn't match an ID in our system.");
                return View(model);
            }

            var service = CreateGoalService();

            if (service.UpdateGoal(model))
            {
                TempData["SaveResult"] = "Your goal has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your goal could not be updated, please give it another try.");
            return RedirectToAction("Index");
        }

        // Delete - Delete Goal
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGoalService();
            var model = svc.GetGoalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGoal(int id)
        {
            var service = CreateGoalService();

            service.DeleteGoal(id);

            TempData["SaveResult"] = "Your goal has successfully been deleted.";

            return RedirectToAction("Index");
        }

        private GoalService CreateGoalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalService(userId);
            return service;
        }
    }
}