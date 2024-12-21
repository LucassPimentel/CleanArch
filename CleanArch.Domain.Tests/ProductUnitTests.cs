using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTests
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            var act = () => new Product("Name", "Description", 1.0m, 1, "image");

            act.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithValidParameter_ResultObjectValidState()
        {
            var act = () => new Product(1, "Name", "Description", 1.0m, 1, "image");

            act.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void UpdateProduct_WithValidParameters_ResultObjectValidState()
        {
            var product = new Product(1, "Name", "Description", 1.0m, 1, "image");

            product.Update("Other Name", "Other Description", 1.0m, 1, "image", 1);

            product.Name.Should().Be("Other Name");
            product.Description.Should().Be("Other Description");
        }

        [Fact]
        public void UpdateProduct_WithInValidParameters_DomainException()
        {
            var product = new Product(1, "Name", "Description", 1.0m, 1, "image");

            var act = () => product.Update("", "Other Description", 1.0m, 1, "image", 1);

            act.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido.");
        }

        [Fact]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            var act = () => new Product(-1, "Name", "Dscription", 1.0m, 1, "image");

            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }

        [Fact]
        public void CreateProduct_WithNullName_DomainExceptionInvalid()
        {
            Action act = () => new Product(1, "", "Description", 1.0m, 1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido.");
        }

        [Fact]
        public void CreateProduct_WithShortName_DomainExceptionInvalidName()
        {
            Action act = () => new Product(1, "Na", "Description", 1.0m, 1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Tamanho inválido. O nome do produto deve ter no mínimo 3 caracteres.");
        }

        [Fact]
        public void CreateProduct_WithLongName_DomainExceptionInvalidName()
        {
            Action act = () => new Product(1, new string('A', 101), "Description", 1.0m, 1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Tamanho inválido. O nome do produto deve ter no máximo 100 caracteres.");
        }

        [Fact]
        public void CreateProduct_WithEmptyDescription_DomainExceptionInvalidDescription()
        {
            Action act = () => new Product(1, "Name", "", 1.0m, 1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Descrição inválida.");
        }

        [Fact]
        public void CreateProduct_WithShortDescription_DomainExceptionInvalidDescription()
        {
            Action act = () => new Product(1, "Name", "Desc", 1.0m, 1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Tamanho inválido. A descrição deve ter no mínimo 5 caracteres.");
        }

        [Fact]
        public void CreateProduct_WithTooLongDescription_DomainExceptionInvalidDescription()
        {
            Action act = () => new Product(1, "Name", new string('A', 301), 1.0m, 1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Tamanho inválido. A descrição do produto deve ter no máximo 300 caracteres.");
        }

        [Fact]
        public void CreateProduct_WithNegativePriceValue_DomainExceptionInvalidDescription()
        {
            Action act = () => new Product(1, "Name", "Description", -1, 1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Preço inválido.");
        }

        [Fact]
        public void CreateProduct_WithNegativeStockValue_DomainExceptionInvalidDescription()
        {
            Action act = () => new Product(1, "Name", "Description", 1, -1, "image");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Valor de estoque inválido.");
        }

        [Fact]
        public void CreateProduct_WithInvalidImageUrl_DomainExceptionInvalidDescription()
        {
            Action act = () => new Product(1, "Name", "Description", 1, 1, new string('A', 251));
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Tamanho inválido. A imagem deve ter no máximo 250 caracteres.");
        }
    }
}
