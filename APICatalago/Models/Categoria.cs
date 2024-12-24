using APICatalogo.Models;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models
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
        public string? ImagemUrl { get; set; }
        //Relacionamento um-para-muitos. Ctaregoria é uma chave estrangeito de produto. 
        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }
    }
}
