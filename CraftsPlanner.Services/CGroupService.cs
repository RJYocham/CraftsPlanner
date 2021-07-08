using CraftsPlanner.Data;
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
    }
}
