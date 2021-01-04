namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTable : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
