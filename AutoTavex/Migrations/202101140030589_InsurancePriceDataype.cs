namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsurancePriceDataype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Insurances", "ContractValue", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Insurances", "ContractValue", c => c.Int(nullable: false));
        }
    }
}
