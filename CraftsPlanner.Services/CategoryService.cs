using CraftsPlanner.Data;
using CraftsPlanner.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Services
{
    public class CategoryService
    {
        //private CGroupService _db = new CGroupService();
        public bool CreateCategory(CategoryCreate model)
        {
            //var cGroup = _db.CGroups.ToArray();
            //model.CGroups = new SelectList(cgroups, "CGroupId", "Name");
            var entity =
                new Category()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    CGroupId = model.CGroupId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    CategoryName = e.CategoryName,
                                    //CGroupId = e.CGroupId
                                }
                                );

                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == id);
                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.CategoryName,
                        CGroupId = entity.CGroupId
                    };
            }
        }

        public bool updateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == model.CategoryId);

                entity.CategoryName = model.CategoryName;
                //add other details to update once made

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CGroupId == CategoryId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
