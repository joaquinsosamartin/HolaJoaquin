﻿namespace Hola.Shopping.Api.Domain.Model
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
