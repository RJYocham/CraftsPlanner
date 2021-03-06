using CraftsPlanner.Models.ProjectGroup;
using CraftsPlanner.Services;
using System.Web.Mvc;

namespace CraftsPlanner.WebMVC.Controllers
{
    public class PGroupController : Controller
    {
        // GET: PGroup
        public ActionResult Index()
        {
            var service = new PGroupService();
            var model = service.GetPGroups();
            return View(model);
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create(int ProjectId)
        {
            var view = new PGroupCreate()
            {
                ProjectId = ProjectId
            };
            return View(view);
        }

        [HttpPost]
        public ActionResult Create(PGroupCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePGroupService();

            if (service.CreatePGroup(model))
            {
                //TempData["SaveResult"] = "Your project group was created.";
                //return RedirectToAction("Index");
            }

            //ModelState.AddModelError("", "Project group could not be created.");

            return RedirectToAction("Details", "Project", new { id = model.ProjectId });
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePGroupService();
            var model = svc.GetPGroupById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePGroupService();
            var detail = service.GetPGroupById(id);
            var model =
                new PGroupEdit
                {
                    PGroupId = detail.PGroupId,
                    PGroupName = detail.PGroupName,
                    ProjectId = detail.ProjectId
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, PGroupEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PGroupId != id)
            {
                //ModelState.AddModelError("", "Id Mismatch");
                //return View(model);
            }

            var service = CreatePGroupService();

            if (service.updatePGroup(model))
            {
                TempData["SaveResult"] = "Your project group was updated.";
                return RedirectToAction("Details", "Project", new { id = model.ProjectId });
            }

            ModelState.AddModelError("", "Your project group cold not be updated.");
            return RedirectToAction("Details", "Project", new { id = model.ProjectId });
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePGroupService();
            var model = svc.GetPGroupById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePGroup(int ProjectId, int id)
        {
            var service = CreatePGroupService();
            service.DeletePGroup(id);
            TempData["SaveResult"] = "Your project group was deleted";
            return RedirectToAction("Details", "Project", new { id = ProjectId });
        }

        private PGroupService CreatePGroupService()
        {
            var service = new PGroupService();
            return service;
        }
    }
}