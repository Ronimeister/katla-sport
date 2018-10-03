namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddManCodePrice : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.catalogue_products", name: "ManufacturerCode", newName: "product_manufacturer_code");
            RenameColumn(table: "dbo.catalogue_products", name: "Price", newName: "product_price");
            AlterColumn("dbo.catalogue_products", "product_manufacturer_code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.catalogue_products", "product_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
            AlterColumn("dbo.catalogue_products", "product_price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.catalogue_products", "product_manufacturer_code", c => c.String());
            RenameColumn(table: "dbo.catalogue_products", name: "product_price", newName: "Price");
            RenameColumn(table: "dbo.catalogue_products", name: "product_manufacturer_code", newName: "ManufacturerCode");
        }
    }
}
