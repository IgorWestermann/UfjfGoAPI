using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UfjfGoAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Migration00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Matricula = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Curso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Photo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cnh = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    User_type_id = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
