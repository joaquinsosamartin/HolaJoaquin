using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hola.Shopping.Api.Application.Dtos;

namespace Hola.Shopping.Api.Application.Contracts.Services
{
    public interface ISizeService
    {
        Task<SizeDto> GetByValue(string value);
        Task<IList<SizeDto>> GetAll();
    }
}
