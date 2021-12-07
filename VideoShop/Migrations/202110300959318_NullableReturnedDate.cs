namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableReturnedDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "ReturnedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "ReturnedDate", c => c.DateTime(nullable: false));
        }
    }
}
