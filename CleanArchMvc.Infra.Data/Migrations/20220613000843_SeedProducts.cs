using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES ('Caderno Espiral', 'Caderno Espiral 100 Folhas', 7.45, 50, 'Caderno1.jpg', 1)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES ('Estojo Escolar', 'Estojo dos Vingadores', 10.45, 70, 'estojovingadores.jpg', 1)");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
