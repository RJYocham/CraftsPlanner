namespace CraftsPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedelementandprojectgroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Element",
                c => new
                    {
                        ElementId = c.Int(nullable: false, identity: true),
                        ElementName = c.String(nullable: false),
                        ElementDescription = c.String(),
                        PGroupId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ElementId)
                .ForeignKey("dbo.ProjectGroup", t => t.PGroupId, cascadeDelete: true)
                .Index(t => t.PGroupId);
            
            CreateTable(
                "dbo.ProjectGroup",
                c => new
                    {
                        PGroupId = c.Int(nullable: false, identity: true),
                        PGroupName = c.String(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Element", "PGroupId", "dbo.ProjectGroup");
            DropIndex("dbo.Element", new[] { "PGroupId" });
            DropTable("dbo.ProjectGroup");
            DropTable("dbo.Element");
        }
    }
}
