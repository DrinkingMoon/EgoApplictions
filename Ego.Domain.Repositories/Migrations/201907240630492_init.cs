namespace Ego.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailItem", "OutBill_ID", c => c.Guid());
            AddColumn("dbo.DetailItem", "WareBill_ID", c => c.Guid());
            CreateIndex("dbo.DetailItem", "OutBill_ID");
            CreateIndex("dbo.DetailItem", "WareBill_ID");
            AddForeignKey("dbo.DetailItem", "OutBill_ID", "dbo.OutdeliverBill", "ID");
            AddForeignKey("dbo.DetailItem", "WareBill_ID", "dbo.WarehousingBill", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailItem", "WareBill_ID", "dbo.WarehousingBill");
            DropForeignKey("dbo.DetailItem", "OutBill_ID", "dbo.OutdeliverBill");
            DropIndex("dbo.DetailItem", new[] { "WareBill_ID" });
            DropIndex("dbo.DetailItem", new[] { "OutBill_ID" });
            DropColumn("dbo.DetailItem", "WareBill_ID");
            DropColumn("dbo.DetailItem", "OutBill_ID");
        }
    }
}
