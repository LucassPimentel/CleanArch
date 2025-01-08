using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres!")]
        public string Name { get; set; }
    }
}
