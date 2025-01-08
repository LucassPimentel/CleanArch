using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [StringLength(70)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido!")]
        [StringLength(70)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        [StringLength(20, ErrorMessage = "A senha deve ter no mínimo 10 e no máximo 20 caracteres!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não são iguais!")]
        public string ConfirmPassword { get; set; }
    }
}
