using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.ProductoLogic
{
    public class ProductoLogic : IProductoLogic
    {
        private readonly IMapper _mapper;

        private readonly IProductoRepository _productoRepository;


        public ProductoLogic(IMapper mapper, IProductoRepository productoRepository)
        {
            this._mapper = mapper;
            this._productoRepository = productoRepository;
        }
        public async Task<ProductoDto> AddAsync(ProductoDto productoDto)
        {
            var entity = await _productoRepository.AddAsync(_mapper.Map<Producto>(productoDto));

            var result = _mapper.Map<ProductoDto>(entity);

            return result;
        }

        public async Task<ProductoDto> FindAsync(int id)
        {
            var entity = await _productoRepository.FindAsync(id);

            var result = _mapper.Map<ProductoDto>(entity);

            return result;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            var entities = await _productoRepository.GetAllAsync();

            var result = _mapper.Map<List<ProductoDto>>(entities);

            return result;
        }

        public async Task<ProductoDto> RemoveAsync(int id)
        {
            var entity = await _productoRepository.RemoveAsync(id);

            var result = _mapper.Map<ProductoDto>(entity);

            return result;
        }

        public async Task<ProductoDto> UpdateAsync(int id, ProductoDto bodegaDto)
        {
            var entity = await _productoRepository.UpdateAsync(id, _mapper.Map<Producto>(bodegaDto));

            var result = _mapper.Map<ProductoDto>(entity);

            return result;
        }
    }
}
