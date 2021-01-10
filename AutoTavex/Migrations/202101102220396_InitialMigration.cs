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
                        Manufacturer = c.String(nullable: false),
                        Series = c.String(nullable: false),
                        TachometerValue = c.Int(nullable: false),
                        HasThermalEngine = c.Boolean(nullable: false),
                        IsHybrid = c.Boolean(nullable: false),
                        IsManual = c.Boolean(nullable: false),
                        Transmission = c.String(maxLength: 10),
                        CylindricalCapacity = c.Short(),
                        HorsePower = c.Short(),
                        YearManufactured = c.Short(),
                        Vin = c.String(nullable: false, maxLength: 17),
                        Image = c.String(),
                        ExtraDetails = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Motoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(nullable: false),
                        Series = c.String(nullable: false),
                        TachometerValue = c.Int(nullable: false),
                        CylindricalCapacity = c.Short(),
                        HorsePower = c.Short(),
                        Caroserie = c.String(),
                        YearManufactured = c.Short(),
                        Vin = c.String(maxLength: 17),
                        Image = c.String(),
                        ExtraDetails = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecialCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Series = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpecialCars");
            DropTable("dbo.Motoes");
            DropTable("dbo.Cars");
        }
    }
}
