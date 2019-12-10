using System;

namespace Hola.Shopping.Api.Application.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string Barcode128 { get; set; }
        public bool IsActive { get; set; }
        public string Category { get; set; }
    }
}
