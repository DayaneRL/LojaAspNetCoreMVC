using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{
    public class Jogo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do jogo deve ser informado")]
        [Display(Name = "Nome do Jogo")]
        [StringLength(80, MinimumLength =10, ErrorMessage = "O {0} dever ter no mínimo {1} e no máximo {2} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do jogo deve ser informada")]
        [Display(Name = "Descrição do Jogo")]
        [MinLength(20, ErrorMessage = "Descrição dever ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição dever ter no máximo {1} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A descrição detalhada do jogo deve ser informada")]
        [Display(Name = "Descrição detalhada do Jogo")]
        [MinLength(20, ErrorMessage = "Descrição detalhada dever ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada dever ter no máximo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "O preço deve ser informado")]
        [Display(Name = "Preço")]
        [Column(TypeName ="decimal(10,2)")] /* 10 digitos com 2 casas decimais */
        [Range(1,999.99, ErrorMessage ="O preço deve ser entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem")]
        [StringLength(200, ErrorMessage = "O {0} dever ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} dever ter no máximo {1} caracteres")]
        public string ThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool JogoPreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
