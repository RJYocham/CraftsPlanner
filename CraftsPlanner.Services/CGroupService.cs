using CraftsPlanner.Data;
using CraftsPlanner.Models.Category;
using CraftsPlanner.Models.CategoryGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Services
{
    public class CGroupService
    {
        private readonly Guid _userId;

        public CGroupService() { }
        public CGroupService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCGroup(CGroupCreate model)
        {
            var entity =
                new CategoryGroup()
                {
                    OwnerId = _userId,
                    CGroupName = model.CGroupName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CGroups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CGroupListItem> GetCGroups()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CGroups
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CGroupListItem
                                {
                                    CGroupId = e.CGroupId,
                                    CGroupName = e.CGroupName
                                }
                                ); 

                return query.ToArray();
            }
        }

        public CGroupDetail GetCGroupById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CGroups
                        .Single(e => e.CGroupId == id && e.OwnerId == _userId);
                return
                    new CGroupDetail
                    {
                        CGroupId = entity.CGroupId,
                        CGroupName = entity.CGroupName,
                        Categories = entity.Categories.Select(x => new CategoryDetail 
                            {  
                                CategoryName = x.CategoryName 
                            }).ToList(),

                        //Categories = 
                    };
            }
        }

        public bool updateCGroup(CGroupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CGroups
                        .Single(e => e.CGroupId == model.CGroupId && e.OwnerId == _userId);
                entity.CGroupName = model.CGroupName;
                //add other details to update once made

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCGroup(int CGroupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CGroups
                        .Single(e => e.CGroupId == CGroupId && e.OwnerId == _userId);

                ctx.CGroups.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
