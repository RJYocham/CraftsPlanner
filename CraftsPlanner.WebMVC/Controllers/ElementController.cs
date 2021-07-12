using CraftsPlanner.Models.Element;
using CraftsPlanner.Services;
using System.Web.Mvc;

namespace CraftsPlanner.WebMVC.Controllers
{
    public class ElementController : Controller
    {
        // GET: Element
        public ActionResult Index()
        {
            var service = new ElementService();
            var model = service.GetElements();
            return View(model);
        }

        public ActionResult Create(int ProjectId, int PGroupId)
        {
            var view = new ElementCreate()
            {
                ProjectId = ProjectId,
                PGroupId = PGroupId
            };
            return View(view);
        }

        [HttpPost]
        public ActionResult Create(ElementCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateElementService();

            if (service.CreateElement(model))
            {
                //TempData["SaveResult"] = "Element was created.";
                //return RedirectToAction("Index");
            }

            //ModelState.AddModelError("", "Element could not be created.");

            return RedirectToAction("Details", "Project", new { id = model.ProjectId });
        }

        public ActionResult Details(int id)
        {
            var svc = CreateElementService();
            var model = svc.GetElementById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateElementService();
            var detail = service.GetElementById(id);
            var model =
                new ElementEdit
                {
                    ElementId = detail.ElementId,
                    ElementName = detail.ElementName,
                    ElementDescription = detail.ElementDescription,
                    PGroupId = detail.PGroupId,
                    IsCompleted = detail.IsCompleted
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, ElementEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ElementId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateElementService();

            if (service.updateElement(model))
            {
                TempData["SaveResult"] = "Your project was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your project cold not be updated.");
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateElementService();
            var model = svc.GetElementById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteElement(int ProjectId, int id)
        {
            var service = CreateElementService();
            service.DeleteElement(id);
            TempData["SaveResult"] = "Your project was deleted";
            return RedirectToAction("Details", "Project", new { id = ProjectId });
        }

        private ElementService CreateElementService()
        {
            var service = new ElementService();
            return service;
        }
    }
}