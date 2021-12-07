namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAmountInStock : DbMigration
    {
        public override void Up()
        {
            Sql(@"
UPDATE Movies SET NumberInStock=20
WHERE name='3 Idiot'
");
        }
        
        public override void Down()
        {
        }
    }
}
