using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;

            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido.");
            DomainExceptionValidation.When(name.Length < 3, "Tamanho inválido. O nome do produto deve ter no mínimo 3 caracteres.");
            DomainExceptionValidation.When(name.Length > 100, "Tamanho inválido. O nome do produto deve ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválida.");
            DomainExceptionValidation.When(description.Length < 5, "Tamanho inválido. A descrição deve ter no mínimo 5 caracteres.");
            DomainExceptionValidation.When(description.Length > 300, "Tamanho inválido. A descrição do produto deve ter no máximo 300 caracteres.");

            DomainExceptionValidation.When(price <= 0, "Preço inválido.");

            DomainExceptionValidation.When(stock < 0, "Valor de estoque inválido.");

            DomainExceptionValidation.When(image.Length > 250, "Tamanho inválido. A imagem deve ter no máximo 250 caracteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
