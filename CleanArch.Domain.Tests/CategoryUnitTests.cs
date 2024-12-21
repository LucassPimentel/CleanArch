using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTests
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action act = () => new Category(1, "Name");

            act
                .Should()
                .NotThrow<DomainExceptionValidation>();

        }

        [Fact]
        public void CreateCategory_WithValidParameter_ResultObjectValidState()
        {
            Action act = () => new Category("Name");

            act
                .Should()
                .NotThrow<DomainExceptionValidation>();

        }

        [Fact]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action act = () => new Category(-1, "Name");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }

        [Fact]
        public void CreateCategory_WithNullName_DomainExceptionInvalid()
        {
            Action act = () => new Category(1, null);
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido.");
        }

        [Fact]
        public void CreateCategory_WithShortName_DomainExceptionInvalidName()
        {
            Action act = () => new Category(1, "Na");
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Tamanho inválido. A categoria deve ter no mínimo 3 caracteres.");
        }

        [Fact]
        public void CreateCategory_WithToLongName_DomainExceptionInvalidName()
        {
            Action act = () => new Category(1, new String('A', 101));
            act
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Tamanho inválido. O nome do produto deve ter no máximo 100 caracteres.");
        }

        [Fact]
        public void UpdateCategory_WithValidParameters_ResultObjectValidState()
        {
            var category = new Category(1, "Name");

            category.Update("Other Name");

            category.Name.Should().Be("Other Name");
        }

        [Fact]
        public void UpdateCategory_WithInvalidParameters_DomainException()
        {
            var category = new Category(1, "Name");

            Action act = () => category.Update("Na");

            act.Should().Throw<DomainExceptionValidation>();
        }
    }
}