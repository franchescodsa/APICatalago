﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalago.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")] //10 digitos e duas casas decimais
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }


        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        //Mapeira para a chave estrangeira no BD
        public int CategoriaId {  get; set; }
        //Propriedade de navegação para indicar que Produto esta relacionado com categoria

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

    }
}
