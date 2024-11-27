namespace APICatalago.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        //Mapeira para a chave estrangeira no BD
        public int CategotiaId {  get; set; }
        //Propriedade de navegação para indicar que Produto esta relacionado com categoria
        public Categoria? Categoria { get; set; }

    }
}
