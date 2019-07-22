namespace Ego.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventory", "Storage_ID", "dbo.Storage");
            DropForeignKey("dbo.Inventory", "Product_ID", "dbo.Product");
            DropIndex("dbo.Inventory", new[] { "Storage_ID" });
            DropIndex("dbo.Inventory", new[] { "Product_ID" });
            DropTable("dbo.Inventory");
            DropTable("dbo.Storage");
            DropTable("dbo.Product");
        }
    }
}
