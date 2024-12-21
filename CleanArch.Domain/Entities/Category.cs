using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }


        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;

            ValidateDomain(name);
        }


        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido.");

            DomainExceptionValidation.When(name.Length < 3, "Tamanho inválido. A categoria deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(name.Length > 100, "Tamanho inválido. O nome do produto deve ter no máximo 100 caracteres.");

            Name = name;
        }


    }

}
