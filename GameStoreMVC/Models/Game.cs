using System.ComponentModel.DataAnnotations;

namespace GameStoreMVC.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descricao é obrigatória")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Dificuldade é obrigatório")]
        public string Dificuldade { get; set; } = string.Empty;
    }
}
