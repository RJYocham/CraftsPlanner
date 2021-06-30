﻿using CraftsPlanner.Data;
using CraftsPlanner.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    OwnerId = _userId,
                    ProjectName = model.ProjectName,
                    Source = model.Source,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProjectListItem
                                {
                                    ProjectId = e.ProjectId,
                                    ProjectName = e.ProjectName,
                                    Source = e.Source
                                }
                               );

                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == id && e.OwnerId == _userId);
                return
                    new ProjectDetail
                    {
                        ProjectId = entity.ProjectId,
                        ProjectName = entity.ProjectName,
                        Source = entity.Source,
                        //Categories = entity.Categories,
                        //Difficulty = entity.Difficulty,
                        //Plan = entity.Plan,
                        //Materials = entity.Materials,
                        //Cost/Budget = entity.Cost + " / " + entity.Budget,
                    };
            }
        }

        public bool updateProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == model.ProjectId && e.OwnerId == _userId);
                entity.ProjectName = model.ProjectName;
                entity.Source = model.Source;
                //add other details to update once made

                return ctx.SaveChanges() == 1;
            }
        }
    }
}