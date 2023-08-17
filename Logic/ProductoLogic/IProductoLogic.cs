using DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.ProductoLogic
{
    public interface IProductoLogic
    {
        public Task<ProductoDto> AddAsync(ProductoDto productoDto);

        public Task<ProductoDto> UpdateAsync(int id, ProductoDto productoDto);

        public Task<ProductoDto> RemoveAsync(int id);

        public Task<IEnumerable<ProductoDto>> GetAllAsync();

        public Task<ProductoDto> FindAsync(int id);
    }
}
