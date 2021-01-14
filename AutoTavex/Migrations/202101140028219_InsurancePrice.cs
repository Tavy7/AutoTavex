namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsurancePrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insurances", "ContractValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insurances", "ContractValue");
        }
    }
}
