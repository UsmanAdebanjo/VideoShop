namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO MembershipTypes(Name,SignUpFee,DiscountRate,DurationInMonth) VALUES('Pay as you go',0,0,0)
INSERT INTO MembershipTypes(Name,SignUpFee,DiscountRate,DurationInMonth) VALUES('Monthly',30,5,1)
INSERT INTO MembershipTypes(Name,SignUpFee,DiscountRate,DurationInMonth) VALUES('Quarterly',60,10,3)
INSERT INTO MembershipTypes(Name,SignUpFee,DiscountRate,DurationInMonth) VALUES('Yearly',100,15,12)

");
        }
        
        public override void Down()
        {
        }
    }
}
