using System;
using System.Collections.Generic;

namespace Hola.Shopping.Api.Domain.Model
{
    public class Size :IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CountryIso { get; set; }
        public bool IsNumeric { get; set; }
        public string Value { get; set; }
        public int? NumericValue { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
