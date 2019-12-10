using System;
using System.Collections.Generic;

namespace Hola.Shopping.Api.Domain.Model
{
    public class Customer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string FullAddress { get; set; }
        public string Email { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
