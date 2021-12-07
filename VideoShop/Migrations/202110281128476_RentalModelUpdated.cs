namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalModelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "BorrowedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "ReturnedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropColumn("dbo.Rentals", "Movie_Id");
            DropColumn("dbo.Rentals", "ReturnedDate");
            DropColumn("dbo.Rentals", "BorrowedDate");
        }
    }
}
