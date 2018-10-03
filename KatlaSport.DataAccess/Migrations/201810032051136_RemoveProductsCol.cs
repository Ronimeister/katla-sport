namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveProductsCol : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.catalogue_products", name: "product_manufacturer_code", newName: "ManufacturerCode");
            RenameColumn(table: "dbo.catalogue_products", name: "product_price", newName: "Price");
            AlterColumn("dbo.catalogue_products", "ManufacturerCode", c => c.String());
            AlterColumn("dbo.catalogue_products", "Price", c => c.Decimal(precision: 18, scale: 2));
        }

        public override void Down()
        {
            AlterColumn("dbo.catalogue_products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.catalogue_products", "ManufacturerCode", c => c.String(nullable: false, maxLength: 10));
            RenameColumn(table: "dbo.catalogue_products", name: "Price", newName: "product_price");
            RenameColumn(table: "dbo.catalogue_products", name: "ManufacturerCode", newName: "product_manufacturer_code");
        }
    }
}
