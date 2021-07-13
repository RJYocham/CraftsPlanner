using CraftsPlanner.Models.Project;
using CraftsPlanner.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace CraftsPlanner.WebMVC.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            //var model = new ProjectListItem[0];
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            var model = service.GetProjects();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = model.ProjectName + " was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Project could not be created.");

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }



        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectId = detail.ProjectId,
                    ProjectName = detail.ProjectName,
                    Source = detail.Source
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.updateProject(model))
            {
                TempData["SaveResult"] = model.ProjectName + " was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", model.ProjectName + " could not be updated.");
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProject(int id)
        {
            var service = CreateProjectService();
            service.DeleteProject(id);
            TempData["SaveResult"] = "Your project was deleted";
            return RedirectToAction("Index");
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}