using APICatalago.Models;
using APICatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models
{
    [Table("Produtos")]
    public class Produto : IValidatableObject
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(20, ErrorMessage = "O nome deve ter entre 5 e 20 catracteres",
            MinimumLength = 5)]
        [PrimeiraLetraMaiusculaAttibute]
        public string? Nome { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "A descrição deve ter no ma´ximo {1} caracteres")]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")] //10 digitos e duas casas decimais
        [Range(1, 1000, ErrorMessage = "O preco deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string? ImagemUrl { get; set; }


        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        //Mapeira para a chave estrangeira no BD
        public int CategoriaId { get; set; }
        //Propriedade de navegação para indicar que Produto esta relacionado com categoria

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nome))
            {
                var primeraLetra = Nome[0].ToString();
                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new
                        ValidationResult("A primeira letra do produto deve ser maiuscula",
                        new[]{nameof(Nome)

                        });
                }
            }
            //Verififcação se a primiera letra é maiuscula

        }
    }
}
