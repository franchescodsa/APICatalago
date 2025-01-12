using APICatalogo.Models;

namespace APICatalogo.Pagination
{
    public class PagedList<T> : List<T>
    {
        //Armazena o número da página atual.
        public int CurrentPage { get; private set; }
        //Armazena o número total de páginas, calculado com base no número total de itens e no tamanho da página.
        public int TotalPages { get; private set; }
        //Armazena o número de itens por página.
        public int PageSize { get; private set; }
        //Armazena o número total de itens.
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        internal static PagedList<Categoria> ToPagedList(IOrderedEnumerable<Categoria> categorias, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
