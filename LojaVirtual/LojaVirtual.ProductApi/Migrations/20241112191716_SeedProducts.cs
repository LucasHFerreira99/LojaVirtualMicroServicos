﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVirtual.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name,Price,Description, Stock, ImageUrl, CategoryId) " +
                "Values ('Caderno', 7.55, 'Caderno', 10, 'Caderno1.jpg', 1)");
            mb.Sql("Insert into Products(Name,Price,Description, Stock, ImageUrl, CategoryId) " +
                 "Values ('Lápis', 3.45, 'Lápis Preto', 20, 'lápis1.jpg', 1)");
            mb.Sql("Insert into Products(Name,Price,Description, Stock, ImageUrl, CategoryId) " +
                 "Values ('Clips', 5.33, 'Clips para papel', 50, 'clips1.jpg', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from products");
        }
    }
}
