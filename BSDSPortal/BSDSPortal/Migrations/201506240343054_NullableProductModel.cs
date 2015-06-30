namespace BSDSPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableProductModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestUnits", "ProductModelID", "dbo.ProductModels");
            DropIndex("dbo.TestUnits", new[] { "ProductModelID" });
            AlterColumn("dbo.TestUnits", "ProductModelID", c => c.Int());
            CreateIndex("dbo.TestUnits", "ProductModelID");
            AddForeignKey("dbo.TestUnits", "ProductModelID", "dbo.ProductModels", "ProductModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestUnits", "ProductModelID", "dbo.ProductModels");
            DropIndex("dbo.TestUnits", new[] { "ProductModelID" });
            AlterColumn("dbo.TestUnits", "ProductModelID", c => c.Int(nullable: false));
            CreateIndex("dbo.TestUnits", "ProductModelID");
            AddForeignKey("dbo.TestUnits", "ProductModelID", "dbo.ProductModels", "ProductModelID", cascadeDelete: true);
        }
    }
}
