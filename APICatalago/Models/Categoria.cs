using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalago.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        [Key] //Mapeando como chave primaria
        public int CategoriaId { get; set; }
        [Required]// coluna vai not null
        [StringLength(80)] // DEFININDO O TAMANHO DA STRING NO BD
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemgUrl { get; set; }
        //Relacionamento um-para-muitos. Ctaregoria é uma chave estrangeito de produto. 
        public ICollection<Produto>? Produtos { get; set; }
    }
}
