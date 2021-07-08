using CraftsPlanner.Models.CategoryGroup;
using CraftsPlanner.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CraftsPlanner.WebMVC.Controllers
{
    public class CategoryGroupController : Controller
    {
        // GET: CategoryGroup
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CGroupService(userId);
            var model = service.GetCGroups();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CGroupCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCGroupService();

            if (service.CreateCGroup(model))
            {
                TempData["SaveResult"] = "You have successfully added a new category group.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category group could not be created");

            return RedirectToAction("Index");
        }



        private CGroupService CreateCGroupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CGroupService(userId);
            return service;
        }
    }
}