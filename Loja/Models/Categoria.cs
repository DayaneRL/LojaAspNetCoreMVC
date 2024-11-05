using System.ComponentModel.DataAnnotations;

namespace Loja.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        public List<Jogo> Jogos { get; set; }
    }
}
