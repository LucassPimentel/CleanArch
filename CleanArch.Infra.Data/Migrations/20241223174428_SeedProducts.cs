using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " + "VALUES('Micro-ondas', 'Com o Micro-ondas sua vida na cozinha ficará muito mais fácil e segura. Ele possui a função “tira odor” que minimiza os odores internos do seu aparelho e um design que facilita no momento da limpeza.', 650.99, 100, 'microondas.png', 1)");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " + "VALUES('Mouse sem fio', 'Resolução máxima de 8000 DPI. Até 70 dias com uma carga completa. Bateria recarregável (500mAh). Conexão com até 3 dispositivos. 3 horas de uso com uma carga de 1 minuto. Tecnologia sem fio avançada de 2,4 GHz.', 599.90, 7, 'mouse.png', 2)");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " + "VALUES('iPhone 12 64GB Preto', 'iPhone12. 5G para baixar filmes de onde estiver e fazer streaming de vídeo em alta qualidade (1)', 2499.50, 2, 'iphone12.png', 3)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
