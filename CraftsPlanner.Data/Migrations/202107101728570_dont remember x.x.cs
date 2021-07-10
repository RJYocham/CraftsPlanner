namespace CraftsPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dontrememberxx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDo", "ToDoGroup_TGroupId", "dbo.ToDoGroup");
            DropForeignKey("dbo.ToDoGroup", "ProjectId", "dbo.Project");
            DropIndex("dbo.ToDoGroup", new[] { "ProjectId" });
            DropIndex("dbo.ToDo", new[] { "ToDoGroup_TGroupId" });
            DropTable("dbo.ToDoGroup");
            DropTable("dbo.ToDo");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ToDoId);
            
            CreateTable(
                "dbo.ToDoGroup",
                c => new
                    {
                        TGroupId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ToDoId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TGroupId);
            
            CreateIndex("dbo.ToDo", "ToDoGroup_TGroupId");
            CreateIndex("dbo.ToDoGroup", "ProjectId");
            AddForeignKey("dbo.ToDoGroup", "ProjectId", "dbo.Project", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.ToDo", "ToDoGroup_TGroupId", "dbo.ToDoGroup", "TGroupId");
        }
    }
}
