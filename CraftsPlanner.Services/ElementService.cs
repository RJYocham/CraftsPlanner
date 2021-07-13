using CraftsPlanner.Data;
using CraftsPlanner.Models.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Services
{
    public class ElementService
    {
        public bool CreateElement(ElementCreate model)
        {
            var entity =
                new Element()
                {
                    ElementName = model.ElementName,
                    ProjectId = model.ProjectId,
                    PGroupId = model.PGroupId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Elements.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ElementListItem> GetElements()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Elements
                        .Select(
                            e =>
                                new ElementListItem
                                {
                                    ElementId = e.ElementId,
                                    ElementName = e.ElementName,
                                    ElementDescription = e.ElementDescription,
                                    //PGroupId = e.PGroupId,
                                    //IsCompleted = e.IsCompleted
                                }
                               );

                return query.ToArray();
            }
        }

        public ElementDetail GetElementById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Elements
                        .Single(e => e.ElementId == id);
                return
                    new ElementDetail
                    {
                        ElementId = entity.ElementId,
                        ElementName = entity.ElementName,
                        ElementDescription = entity.ElementDescription,
                        ProjectId = entity.ProjectId,
                        PGroupId = entity.PGroupId,
                        IsCompleted = entity.IsCompleted
                    };
            }
        }

        public bool updateElement(ElementEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Elements
                        .Single(e => e.ElementId == model.ElementId);

                entity.ProjectId = model.ProjectId;
                entity.ElementName = model.ElementName;
                entity.ElementDescription = model.ElementDescription;
                entity.PGroupId = model.PGroupId;
                entity.IsCompleted = model.IsCompleted;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteElement(int elementId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Elements
                        .Single(e => e.ElementId == elementId);

                ctx.Elements.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
