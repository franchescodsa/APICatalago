using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace APICatalago.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemgUrl { get; set; }
        //Relacionamento um-para-muitos. Ctaregoria é uma chave estrangeito de produto. 
        public ICollection<Produto>? Produtos { get; set; }
    }
}
