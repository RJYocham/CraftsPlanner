namespace CraftsPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryGroup",
                c => new
                    {
                        CGroupId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CGroupName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CGroupId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CGroupId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.CategoryGroup", t => t.CGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.Project_ProjectId)
                .Index(t => t.CGroupId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.ToDoGroup",
                c => new
                    {
                        TGroupId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ToDoId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TGroupId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ToDo",
                c => new
                    {
                        ToDoId = c.Int(nullable: false, identity: true),
                        ToDoName = c.String(nullable: false),
                        ToDoDescription = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        ToDoGroup_TGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.ToDoId)
                .ForeignKey("dbo.ToDoGroup", t => t.ToDoGroup_TGroupId)
                .Index(t => t.ToDoGroup_TGroupId);
            
            AddColumn("dbo.Project", "Created", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoGroup", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ToDo", "ToDoGroup_TGroupId", "dbo.ToDoGroup");
            DropForeignKey("dbo.Category", "Project_ProjectId", "dbo.Project");
            DropForeignKey("dbo.Category", "CGroupId", "dbo.CategoryGroup");
            DropIndex("dbo.ToDo", new[] { "ToDoGroup_TGroupId" });
            DropIndex("dbo.ToDoGroup", new[] { "ProjectId" });
            DropIndex("dbo.Category", new[] { "Project_ProjectId" });
            DropIndex("dbo.Category", new[] { "CGroupId" });
            DropColumn("dbo.Project", "Created");
            DropTable("dbo.ToDo");
            DropTable("dbo.ToDoGroup");
            DropTable("dbo.Category");
            DropTable("dbo.CategoryGroup");
        }
    }
}
