namespace Ego.Domain.Repositories.EFDbContextEgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        StockQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(),
                        EntryTime = c.DateTime(nullable: false),
                        Product_ID = c.Guid(),
                        Storage_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .ForeignKey("dbo.Storage", t => t.Storage_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.Storage_ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Spec = c.String(),
                        Producttype = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Storage",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.StockInItem",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        BillNo = c.String(),
                        OperationCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(),
                        Product_ID = c.Guid(),
                        StockInBill_ID = c.Guid(),
                        Storage_ID = c.Guid(),
                        StockOutBill_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .ForeignKey("dbo.StockInBill", t => t.StockInBill_ID)
                .ForeignKey("dbo.Storage", t => t.Storage_ID)
                .ForeignKey("dbo.StockOutBill", t => t.StockOutBill_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.StockInBill_ID)
                .Index(t => t.Storage_ID)
                .Index(t => t.StockOutBill_ID);
            
            CreateTable(
                "dbo.StockOutBill",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        BillNo = c.String(),
                        CreateTime = c.String(),
                        CreateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockInItem", "StockOutBill_ID", "dbo.StockOutBill");
            DropForeignKey("dbo.StockInItem", "Storage_ID", "dbo.Storage");
            DropForeignKey("dbo.StockInItem", "StockInBill_ID", "dbo.StockInBill");
            DropForeignKey("dbo.StockInItem", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.Inventory", "Storage_ID", "dbo.Storage");
            DropForeignKey("dbo.Inventory", "Product_ID", "dbo.Product");
            DropIndex("dbo.StockInItem", new[] { "StockOutBill_ID" });
            DropIndex("dbo.StockInItem", new[] { "Storage_ID" });
            DropIndex("dbo.StockInItem", new[] { "StockInBill_ID" });
            DropIndex("dbo.StockInItem", new[] { "Product_ID" });
            DropIndex("dbo.Inventory", new[] { "Storage_ID" });
            DropIndex("dbo.Inventory", new[] { "Product_ID" });
            DropTable("dbo.StockOutBill");
            DropTable("dbo.StockInItem");
            DropTable("dbo.StockInBill");
            DropTable("dbo.Storage");
            DropTable("dbo.Product");
            DropTable("dbo.Inventory");
        }
    }
}
