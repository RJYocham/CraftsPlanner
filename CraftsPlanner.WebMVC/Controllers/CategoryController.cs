using CraftsPlanner.Models.Category;
using CraftsPlanner.Services;
using System.Web.Mvc;

namespace CraftsPlanner.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var service = new CategoryService();
            var model = service.GetCategories();
            return View(model);
        }

        public ActionResult Create()
        {
           // List<CategoryGroup> CGroups = (new CGroupService()).GetCGroups().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "You have successfully added a new category.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be created");
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCategoryService();
            var detail = service.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    CategoryId = detail.CategoryId,
                    CategoryName = detail.CategoryName
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCategoryService();

            if (service.updateCategory(model))
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
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCategory(int id)
        {
            var service = CreateCategoryService();
            service.DeleteCategory(id);
            TempData["SaveResult"] = "Your project was deleted";
            return RedirectToAction("Index");
        }

        private CategoryService CreateCategoryService()
        {
            var service = new CategoryService();
            return service;
        }
    }
}