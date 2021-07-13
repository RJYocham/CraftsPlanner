namespace CraftsPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingthings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Element", "ProjectId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Element", "ProjectId");
        }
    }
}
