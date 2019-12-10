using System;
using System.Collections.Generic;

namespace Hola.Shopping.Api.Domain.Model
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Size Size { get; set; }
        public string Color { get; set; }
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string Barcode128 { get; set; }
        public bool IsActive { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
