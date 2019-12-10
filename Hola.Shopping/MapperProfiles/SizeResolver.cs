using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Hola.Shopping.Api.Application.Contracts.Services;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Domain.Model;

namespace Hola.Shopping.Api.MapperProfiles
{
    public class SizeResolver : IValueResolver<ProductDto, Product, Size>
    {
        private readonly ISizeService _sizeService;
        private readonly IMapper _mapper;

        public SizeResolver(ISizeService sizeService, IMapper mapper)
        {
            _sizeService = sizeService;
            _mapper = mapper;
        }

        public Size Resolve(ProductDto source, Product destination, Size destMember, ResolutionContext context)
        {
            var sizeDto =  int.TryParse(source.Size, out var numericValue)
                ? Task.Run(async () => await _sizeService.GetByValue(numericValue.ToString(CultureInfo.InvariantCulture))).Result
                : Task.Run(async () => await _sizeService.GetByValue(source.Size)).Result;

            return _mapper.Map<SizeDto, Size>(sizeDto);
        }
    }
}