using Hola.Shopping.Api.Application.Dtos;

namespace Hola.Shopping.Api.Model
{
    public class GetProductsPagedRequest : PagedFilter
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Reference { get; set; }
    }
}
