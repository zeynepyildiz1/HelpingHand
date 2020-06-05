using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHandProject.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "District", "FirstName", "IsUser", "LastName", "Mail", "Password", "PhoneNumber", "Province", "UserImage" },
                values: new object[] { 1, null, new DateTime(1998, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kağıthane", "Zeynep", true, "Yıldız", "azeynepyildiz1@gmail.com", "123456", "05349286464", "İstanbul", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "District", "FirstName", "IsUser", "LastName", "Mail", "Password", "PhoneNumber", "Province", "UserImage" },
                values: new object[] { 2, null, new DateTime(2001, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kağıthane", "Ali", true, "Şahin", "zeyeess@gmail.com", "123456", "05349286464", "İstanbul", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "District", "FirstName", "IsUser", "LastName", "Mail", "Password", "PhoneNumber", "Province", "UserImage" },
                values: new object[] { 3, null, new DateTime(1991, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kağıthane", "İrem", true, "Yıldırım", "irem@gmail.com", "123456", "05349286464", "İstanbul", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "PostCategory", "PostDate", "PostImage", "PostText", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dünya Sağlık Örgütü tarafından pandemi olarak belirtilen Koronavirüs`le mücadele sürecinde hastanemizdeki sağlık personelinin kullanabilmesi için aşağıdaki malzemelere ihtiyacımız bulunmaktadır.", 1 },
                    { 4, true, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dünya Sağlık Örgütü tarafından pandemi olarak belirtilen Koronavirüs`le mücadele sürecinde hastanemizdeki sağlık personelinin kullanabilmesi için aşağıdaki malzemelere ihtiyacımız bulunmaktadır.", 1 },
                    { 2, true, new DateTime(2010, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Koronavirüs salgını nedeni ile azalan hasta sayımıza rağmen günde yaklaşık 150 hasta bakmaktayız. Dezenfektan temin etme konusunda sıkıntı yaşamaktayız.", 2 },
                    { 5, false, new DateTime(2010, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İhtiyacı olan 3 öğrenciye burs vereceğim.", 2 },
                    { 3, true, new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gelen hastaların ateşini temassız ölçebilmek için alından ölçen ateş ölçerler mevcut ihtiyacı olan hastaneler yollayabilirim.", 3 },
                    { 6, false, new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Geçen seneden kalan ygs kitaplarım duruyor dileyene gönderebilirim.", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentDate", "CommentText", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesaj atarsanız eğer ben yardımcı olabilirim", 1, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentDate", "CommentText", "PostId", "UserId" },
                values: new object[] { 2, new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbulda da aynı sorun var.Yardımlarınızı bekliyoruz", 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
