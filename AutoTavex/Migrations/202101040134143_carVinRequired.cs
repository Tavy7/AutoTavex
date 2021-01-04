namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carVinRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Vin", c => c.String(nullable: false, maxLength: 17));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Vin", c => c.String(maxLength: 17));
        }
    }
}
