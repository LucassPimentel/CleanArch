using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        [StringLength(20, ErrorMessage = "A senha deve ter no mínimo 10 e no máximo 20 caracteres!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
