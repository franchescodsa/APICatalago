using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        [Required]// coluna vai not null
        [StringLength(80)] // DEFININDO O TAMANHO DA STRING NO BD
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
    }
}
