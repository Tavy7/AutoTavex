namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HasThermalEngine = c.Boolean(nullable: false),
                        IsHybrid = c.Boolean(nullable: false),
                        CylindricalCapacity = c.Short(nullable: false),
                        HorsePower = c.Short(nullable: false),
                        YearManufactured = c.Short(nullable: false),
                        Vin = c.String(maxLength: 17),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
