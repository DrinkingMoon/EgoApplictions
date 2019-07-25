namespace Ego.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DetailItem", newName: "StockInItem");
            RenameTable(name: "dbo.OutdeliverBill", newName: "StockOutBill");
            CreateTable(
                "dbo.StockInBill",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        BillNo = c.String(),
                        CreateTime = c.String(),
                        CreateUser = c.String(),
                        BillStatus = c.String(),
                        AffirmDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.StockInItem", "StockInBill_ID", c => c.Guid());
            AddColumn("dbo.StockInItem", "StockOutBill_ID", c => c.Guid());
            CreateIndex("dbo.StockInItem", "StockInBill_ID");
            CreateIndex("dbo.StockInItem", "StockOutBill_ID");
            AddForeignKey("dbo.StockInItem", "StockInBill_ID", "dbo.StockInBill", "ID");
            AddForeignKey("dbo.StockInItem", "StockOutBill_ID", "dbo.StockOutBill", "ID");
            DropTable("dbo.WarehousingBill");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WarehousingBill",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        BillNo = c.String(),
                        CreateTime = c.String(),
                        CreateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.StockInItem", "StockOutBill_ID", "dbo.StockOutBill");
            DropForeignKey("dbo.StockInItem", "StockInBill_ID", "dbo.StockInBill");
            DropIndex("dbo.StockInItem", new[] { "StockOutBill_ID" });
            DropIndex("dbo.StockInItem", new[] { "StockInBill_ID" });
            DropColumn("dbo.StockInItem", "StockOutBill_ID");
            DropColumn("dbo.StockInItem", "StockInBill_ID");
            DropTable("dbo.StockInBill");
            RenameTable(name: "dbo.StockOutBill", newName: "OutdeliverBill");
            RenameTable(name: "dbo.StockInItem", newName: "DetailItem");
        }
    }
}
