namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO Genres(Id,Name) Values(1,'Action')
INSERT INTO Genres(Id,Name) Values(2,'Family')
INSERT INTO Genres(Id,Name) Values(3,'Romance')
INSERT INTO Genres(Id,Name) Values(4,'Passion')
");
        }
        
        public override void Down()
        {
        }
    }
}
