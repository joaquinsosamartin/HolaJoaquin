using System;

namespace Hola.Shopping.Api.Domain.Model
{
    public class Attachment : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileUrl { get; set; }
        public DateTime InsertDate { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
