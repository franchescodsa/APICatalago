using APICatalogo.Models;

namespace APICatalogo.DTOs.Mappings
{
    public static class CategoriaDTOMappingsExtensions
    {
        public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
        {
            if (categoria == null)
            {
                return null;
            }
            return new CategoriaDTO
            {
                CategoriaId = categoria.CategoriaId,
                Nome = categoria.Nome,
                ImagemUrl = categoria.ImagemUrl
            };
        }
        public static Categoria? ToCategoria(this CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                return null;
            }
            return new Categoria
            {
                CategoriaId = categoriaDTO.CategoriaId,
                Nome = categoriaDTO.Nome,
                ImagemUrl = categoriaDTO.ImagemUrl
            };
        }
        public static IEnumerable<CategoriaDTO> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
        {
            // Cria uma lista para armazenar os objetos CategoriaDTO
            List<CategoriaDTO> categoriasDTO = new List<CategoriaDTO>();

            // Itera sobre cada objeto Categoria na coleção de categorias
            foreach (var categoria in categorias)
            {
                // Verifica se a categoria não é nula
                if (categoria != null)
                {
                    // Converte a categoria para CategoriaDTO e adiciona à lista
                    categoriasDTO.Add(categoria.ToCategoriaDTO());
                }
            }

            // Retorna a lista de CategoriaDTOs
            return categoriasDTO;
        }
    }
}
