namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carYearManufacturedIsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "YearManufactured", c => c.Short());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "YearManufactured", c => c.Short(nullable: false));
        }
    }
}
