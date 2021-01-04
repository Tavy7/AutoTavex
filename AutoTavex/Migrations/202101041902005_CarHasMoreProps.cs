namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarHasMoreProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "TachometerValue", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "IsManual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Transmission", c => c.String(maxLength: 10));
            AddColumn("dbo.Cars", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Price");
            DropColumn("dbo.Cars", "Transmission");
            DropColumn("dbo.Cars", "IsManual");
            DropColumn("dbo.Cars", "TachometerValue");
        }
    }
}
