using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória!")]
        [MinLength(3, ErrorMessage = "Mínimo de 5 caracteres!")]
        [MaxLength(300, ErrorMessage = "Máximo de 300 caracteres!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório!")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Estoque é obrigatório!")]
        [Range(1, 9999, ErrorMessage = "Mínimo de 1 e máximo 9999")]
        public int Stock { get; set; }

        [MaxLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        public string Image { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Categoria")]
        public Category? Category { get; set; }
    }
}
