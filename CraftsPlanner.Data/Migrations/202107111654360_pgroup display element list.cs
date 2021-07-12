namespace CraftsPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pgroupdisplayelementlist : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProjectGroup", "ProjectId");
            AddForeignKey("dbo.ProjectGroup", "ProjectId", "dbo.Project", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectGroup", "ProjectId", "dbo.Project");
            DropIndex("dbo.ProjectGroup", new[] { "ProjectId" });
        }
    }
}
