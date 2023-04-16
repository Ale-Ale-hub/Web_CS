using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_C_.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_Price_Name_Amount", x => new { x.Price, x.Name, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Email_Phone", x => new { x.Email, x.Phone });
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Description", "Discriminator", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10, "Samsung Galaxy A23 – отличный пример современного функционального смартфона, который обеспечивает хорошую производительность, более чем достойную автономность и не помешает превратить яркий момент в незабываемый кадр. Он получил современный дисплей с частотой обновления до 90 Гц и разрешением FHD+, восьмиядерный процессор и достойный запас оперативной памяти и хранилища.", "PhoneDto", "Samsung Galaxy A23 4/64 ГБ, черный", 45780m },
                    { 2, 5, "Смартфон Galaxy A32 оснащён гибко настраиваемым экраном «Always On Display» - вместо обычного индикатора уведомлений, вы получаете возможность пользоваться базовыми функциями и считывать необходимую информацию из выключенного экрана, что также помогает экономить лишний расход заряда батареи.", "PhoneDto", "Samsung Galaxy A23 4/64 ГБ, черный", 25670m },
                    { 3, 20, "iPhone 14 Pro (6.1\") противоударный Прозрачный купить в Москве дешево с доставкой. Чехол-накладка силикон Deppa Gel Shockproof Case D-88325 для iPhone 14 Pro (6.1\") противоударный Прозрачный – продажа по низкой цене с гарантией. Фото, технические характеристики, отзывы, аксессуары, видео – все это поможет вам определиться с выбором.", "PhoneDto", "Apple iPhone 11 64GB Black (черный) A2221", 15490m },
                    { 4, 50, "Лучший дисплей iPhone с невероятной контрастностью и более высоким разрешением. И передняя панель Ceramic Shield, с которой риск повреждений дисплея при падении в четыре раза ниже.", "PhoneDto", "Apple iPhone 14 Pro Max 1Tb Deep Purple (тёмно-фиолетовый) A2894", 143999m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
