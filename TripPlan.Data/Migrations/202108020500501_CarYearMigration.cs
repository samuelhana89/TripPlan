namespace TripPlan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarYearMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentACar",
                c => new
                    {
                        RentACarId = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        Model = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentACarId)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentACar", "TripId", "dbo.Trip");
            DropIndex("dbo.RentACar", new[] { "TripId" });
            DropTable("dbo.RentACar");
        }
    }
}
