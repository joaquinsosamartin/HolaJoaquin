using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hola.Shopping.Api.Application.Contracts.Services;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Data.Contracts;
using Hola.Shopping.Api.Domain.Model;

namespace Hola.Shopping.Api.Application.Implementation.Services
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SizeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IList<SizeDto>> GetAll()
        {
            var sizes = await _unitOfWork.SizeRepository.GetAll();
            return _mapper.Map<IList<Size>, IList<SizeDto>>(sizes.ToList());
        }

        public async Task<SizeDto> GetByValue(string value)
        {
            var size = int.TryParse(value, out var numericValue)
                ? await _unitOfWork.SizeRepository.GetByNumericValue(numericValue)
                : await _unitOfWork.SizeRepository.GetByStringValue(value);
            
            return _mapper.Map<Size, SizeDto>(size);
        }
    }
}
