namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotoCreated : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Cars", "ExtraDetails", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "ExtraDetails");
            DropTable("dbo.Motoes");
        }
    }
}
