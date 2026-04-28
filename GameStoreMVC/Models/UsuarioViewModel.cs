using System.ComponentModel.DataAnnotations;

namespace GameStoreMVC.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "A confirmação da senha é obrigatório")]
        public string ConfirmacaoSenha { get; set; } = string.Empty;

    }
}
