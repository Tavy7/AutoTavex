namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsuranceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DurationInYears = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false),
                        CustomerCNP = c.String(nullable: false),
                        CarName = c.String(nullable: false),
                        CarVIN = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Insurances");
        }
    }
}
