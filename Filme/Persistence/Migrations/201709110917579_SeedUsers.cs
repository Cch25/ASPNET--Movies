using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e2045e9-3d20-46f0-be82-9d473792a7b7', N'c.chiritoiu25@yahoo.com', 0, N'APZ4dPqwxRX+CxdPbcge6kGBQ811RGKe7L7h6R8bXbiCZTdvcWsx+8dekngX4jNYIw==', N'fc0717d4-8a77-4109-a704-f29c38e78948', NULL, 0, 0, NULL, 1, 0, N'c.chiritoiu25@yahoo.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a897e42d-0132-4e61-87fd-de025fe0342c', N'bear@gmail.com', 0, N'ABJ7xuAts+E4m6KPCOyMQzNBk/uJsRI6eK3AtDH6GE+EABpGDqF4RrcO48rkFLlrZw==', N'bb99f914-e7c9-4116-8238-2c2d741062f7', NULL, 0, 0, NULL, 1, 0, N'bear@gmail.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'55236127-fb6c-4643-bb4c-275ff59b73f8', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a897e42d-0132-4e61-87fd-de025fe0342c', N'55236127-fb6c-4643-bb4c-275ff59b73f8')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
