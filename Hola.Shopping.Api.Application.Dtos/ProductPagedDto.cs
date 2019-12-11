namespace Hola.Shopping.Api.Application.Dtos
{
    public class ProductPagedDto : PagedFilter
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Reference { get; set; }
    }
}
