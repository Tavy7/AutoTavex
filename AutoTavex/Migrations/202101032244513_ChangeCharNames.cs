namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCharNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Manufacturer", c => c.String(nullable: false));
            AddColumn("dbo.Cars", "Series", c => c.String(nullable: false));
            DropColumn("dbo.Cars", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Cars", "Series");
            DropColumn("dbo.Cars", "Manufacturer");
        }
    }
}
