using System;
using System.Collections.Generic;
using System.Text;

namespace Hola.Shopping.Api.Application.Dtos
{
    public class SizeDto
    {
        public Guid Id { get; set; }
        public string CountryIso { get; set; }
        public bool IsNumeric { get; set; }
        public string Value { get; set; }
        public int? NumericValue { get; set; }
    }
}
