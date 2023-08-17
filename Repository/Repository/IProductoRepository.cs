using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IProductoRepository
    {
        public Task<Producto> AddAsync(Producto producto);

        public Task<Producto> UpdateAsync(int id, Producto producto);

        public Task<Producto> RemoveAsync(int id);

        public Task<Producto> FindAsync(int id);

        public Task<IEnumerable<Producto>> GetAllAsync();
    }
}
