using System;

namespace Hola.Shopping.Api.Domain.Model
{
    public class ProductOrder
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
