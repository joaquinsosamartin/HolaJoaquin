namespace Hola.Shopping.Api.Application.Dtos
{
    public class PagedFilter
    {
        public int StartRowIndex { get; set; }
        public int MaximumRows { get; set; }
        public string SortParameter { get; set; }
        public int SortOrder { get; set; }
    }
}
