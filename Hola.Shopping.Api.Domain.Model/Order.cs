using System;
using System.Collections.Generic;

namespace Hola.Shopping.Api.Domain.Model
{
    public class Order : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
