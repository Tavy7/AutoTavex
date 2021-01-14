namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsuranceCarId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insurances", "CarId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insurances", "CarId");
        }
    }
}
