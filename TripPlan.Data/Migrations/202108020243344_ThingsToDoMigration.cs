namespace TripPlan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThingsToDoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThingsToDo",
                c => new
                    {
                        ThingsToDoId = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        Activity = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThingsToDoId)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThingsToDo", "TripId", "dbo.Trip");
            DropIndex("dbo.ThingsToDo", new[] { "TripId" });
            DropTable("dbo.ThingsToDo");
        }
    }
}
