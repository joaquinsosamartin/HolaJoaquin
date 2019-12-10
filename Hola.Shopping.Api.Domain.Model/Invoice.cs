using System;
using System.Collections.Generic;

namespace Hola.Shopping.Api.Domain.Model
{
    public class Invoice : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
