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

        public ActionResult Details(int id)
        {
            var svc = CreateCGroupService();
            var model = svc.GetCGroupById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCGroupService();
            var detail = service.GetCGroupById(id);
            var model =
                new CGroupEdit
                {
                    CGroupId = detail.CGroupId,
                    CGroupName = detail.CGroupName
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CGroupEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CGroupId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCGroupService();

            if (service.updateCGroup(model))
            {
                TempData["SaveResult"] = "This group was successfully updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This group could not be updated.");
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCGroupService();
            var model = svc.GetCGroupById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCGroup(int id)
        {
            var service = CreateCGroupService();
            service.DeleteCGroup(id);
            TempData["SaveResult"] = "Your project was deleted";
            return RedirectToAction("Index");
        }

        //public PartialViewResult Sidebar()
        //{
        //    return PartialView();
        //}

        private CGroupService CreateCGroupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CGroupService(userId);
            return service;
        }
    }
}