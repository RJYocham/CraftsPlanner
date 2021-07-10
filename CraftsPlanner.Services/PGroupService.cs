using CraftsPlanner.Data;
using CraftsPlanner.Models.ProjectGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Services
{
    public class PGroupService
    {
        public bool CreatePGroup(PGroupCreate model)
        {
            var entity =
                new ProjectGroup()
                {
                    PGroupName = model.PGroupName,
                    ProjectId = model.ProjectId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PGroups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PGroupListItem> GetPGroups()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PGroups
                        .Select(
                            e =>
                                new PGroupListItem
                                {
                                    PGroupId = e.PGroupId,
                                    PGroupName = e.PGroupName,
                                    ProjectId = e.ProjectId
                                }
                               );

                return query.ToArray();
            }
        }

        public PGroupDetail GetPGroupById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PGroups
                        .Single(e => e.PGroupId == id);
                return
                    new PGroupDetail
                    {
                        PGroupId = entity.PGroupId,
                        PGroupName = entity.PGroupName,
                        ProjectId = entity.ProjectId
                    };
            }
        }

        public bool updateElement(PGroupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PGroups
                        .Single(e => e.PGroupId == model.PGroupId);

                entity.PGroupName = model.PGroupName;
                entity.ProjectId = model.ProjectId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePGroup(int pGroupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PGroups
                        .Single(e => e.PGroupId == pGroupId);

                ctx.PGroups.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
