namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "CylindricalCapacity", c => c.Short());
            AlterColumn("dbo.Cars", "HorsePower", c => c.Short());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "HorsePower", c => c.Short(nullable: false));
            AlterColumn("dbo.Cars", "CylindricalCapacity", c => c.Short(nullable: false));
        }
    }
}
