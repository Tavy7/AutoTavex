namespace AutoTavex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.EventId);
            
            AddColumn("dbo.Cars", "VehicleEvent_EventId", c => c.Int());
            AddColumn("dbo.Cars", "VehicleEvent_EventId1", c => c.Int());
            AddColumn("dbo.Motoes", "VehicleEvent_EventId", c => c.Int());
            AddColumn("dbo.Motoes", "VehicleEvent_EventId1", c => c.Int());
            CreateIndex("dbo.Cars", "VehicleEvent_EventId");
            CreateIndex("dbo.Cars", "VehicleEvent_EventId1");
            CreateIndex("dbo.Motoes", "VehicleEvent_EventId");
            CreateIndex("dbo.Motoes", "VehicleEvent_EventId1");
            AddForeignKey("dbo.Cars", "VehicleEvent_EventId", "dbo.VehicleEvents", "EventId");
            AddForeignKey("dbo.Motoes", "VehicleEvent_EventId", "dbo.VehicleEvents", "EventId");
            AddForeignKey("dbo.Cars", "VehicleEvent_EventId1", "dbo.VehicleEvents", "EventId");
            AddForeignKey("dbo.Motoes", "VehicleEvent_EventId1", "dbo.VehicleEvents", "EventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Motoes", "VehicleEvent_EventId1", "dbo.VehicleEvents");
            DropForeignKey("dbo.Cars", "VehicleEvent_EventId1", "dbo.VehicleEvents");
            DropForeignKey("dbo.Motoes", "VehicleEvent_EventId", "dbo.VehicleEvents");
            DropForeignKey("dbo.Cars", "VehicleEvent_EventId", "dbo.VehicleEvents");
            DropIndex("dbo.Motoes", new[] { "VehicleEvent_EventId1" });
            DropIndex("dbo.Motoes", new[] { "VehicleEvent_EventId" });
            DropIndex("dbo.Cars", new[] { "VehicleEvent_EventId1" });
            DropIndex("dbo.Cars", new[] { "VehicleEvent_EventId" });
            DropColumn("dbo.Motoes", "VehicleEvent_EventId1");
            DropColumn("dbo.Motoes", "VehicleEvent_EventId");
            DropColumn("dbo.Cars", "VehicleEvent_EventId1");
            DropColumn("dbo.Cars", "VehicleEvent_EventId");
            DropTable("dbo.VehicleEvents");
        }
    }
}