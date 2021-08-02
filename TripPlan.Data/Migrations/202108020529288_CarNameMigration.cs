namespace TripPlan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentACar", "CarName", c => c.String(nullable: false));
            DropColumn("dbo.RentACar", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentACar", "Model", c => c.String(nullable: false));
            DropColumn("dbo.RentACar", "CarName");
        }
    }
}
