using System;
using System.Collections.Generic;

namespace Hola.Shopping.Api.Domain.Model
{
    public class Shop : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FiscalCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
