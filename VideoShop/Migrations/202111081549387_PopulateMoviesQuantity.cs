namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesQuantity : DbMigration
    {
        public override void Up()
        {
            Sql(@"
UPDATE Movies SET NumberInStock=40, AvailabileInStock=40
WHERE Id>=1
");
        }
        
        public override void Down()
        {
        }
    }
}
