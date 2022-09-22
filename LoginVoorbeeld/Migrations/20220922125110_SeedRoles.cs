using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginVoorbeeld.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string StudentRoleId = Guid.NewGuid().ToString();
        private string EmployeeRoleId = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
            SeedUser(migrationBuilder);
            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp]) 
            VALUES ('{ StudentRoleId }', 'Student', 'STUDENT', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp]) 
            VALUES ('{EmployeeRoleId}', 'Employee', 'EMPLOYEE', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],
                [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
                VALUES
                (N'{User1Id}', N'Test 1', N'Lastname', N'test1@gmail.com', N'TEST1@GMAIL.COM', N'test1@gmail.com', N'TEST1@GMAIL.COM', 0, 
                N'AQAAAAEAACcQAAAAEHBNboRmmHrAZiAzhaBu4pyFhP4MRoivQ4X4YlwG9tDg2wUkOyiPCz4l6TW+qYO89Q==', 
                'WNW6ADCIQQ6N3BYWIMTMKIB4C6RCUYRJ', 'e037398e-c7e4-41fc-afb4-753545ae2f7d', NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
               @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],
                [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
                VALUES
                (N'{User2Id}', N'Test 1', N'Lastname', N'student@gmail.com', N'STUDENT@GMAIL.COM', N'student@gmail.com', N'STUDENT@GMAIL.COM', 0, 
                N'AQAAAAEAACcQAAAAEHBNboRmmHrAZiAzhaBu4pyFhP4MRoivQ4X4YlwG9tDg2wUkOyiPCz4l6TW+qYO89Q==', 
                'WNW6ADCIQQ6N3BYWIMTMKIB4C6RCUYRJ', 'e037398e-c7e4-41fc-afb4-753545ae2f7d', NULL, 0, 0, NULL, 1, 0)");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
            INSERT INTO [dbo].[AspNetUserRoles]
            ([UserId],[RoleId])
            VALUES
            ('{User1Id}', '{StudentRoleId}');");

            migrationBuilder.Sql(@$"
            INSERT INTO [dbo].[AspNetUserRoles]
            ([UserId],[RoleId])
            VALUES
            ('{User2Id}', '{EmployeeRoleId}');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
