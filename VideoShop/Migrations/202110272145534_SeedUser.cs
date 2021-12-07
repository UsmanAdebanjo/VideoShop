namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5b8c1c39-cdd3-4a24-9466-8a880b01ba7f', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4dacc635-b1fc-4275-b300-90d91e90b382', N'guest@videoshop.com', 0, N'AJhBsOzGMTyrmo6snDRf1KyvGQ7fZp3QFe4yCcQTPisxTqzAX8l4/yeh0PEuIAgvJw==', N'3b199711-0032-4997-b528-0080cc364e78', NULL, 0, 0, NULL, 1, 0, N'guest@videoshop.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'19f367cb-b444-4291-9cb5-750c9ecb9ca7', N'admin@videoshop.com', 0, N'AOLUiV2zKh+DNzuKj3aDP2PRbjNV+WqfaydTYlVQS/5yt3LmZ9Eqs6NDL1tOK0suKw==', N'5ea540e2-8e0a-44f4-9673-1ff417ef84f5', NULL, 0, 0, NULL, 1, 0, N'admin@videoshop.com')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'19f367cb-b444-4291-9cb5-750c9ecb9ca7', N'5b8c1c39-cdd3-4a24-9466-8a880b01ba7f')

");
        }
        
        public override void Down()
        {
        }
    }
}
