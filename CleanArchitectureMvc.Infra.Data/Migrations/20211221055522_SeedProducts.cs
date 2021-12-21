using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitectureMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " + 
                                 " VALUES('Caderno espieral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                                 " VALUES('Estojo escolar', 'Estojo escolar cinza', 5.50, 25, 'estojo.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                                 " VALUES('Borracha Escolar', 'Borracha Escolar pequena', 3.25, 80, 'borracha.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                                 " VALUES('Calculadora', 'Calculadora simples', 22.30, 10, 'calculadora.jpg', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
