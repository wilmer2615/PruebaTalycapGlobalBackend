using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IBodegaRepository
    {
        public Task<Bodega> AddAsync(Bodega bodega);

        public Task<Bodega> UpdateAsync(int id, Bodega bodega);

        public Task<Bodega> RemoveAsync(int id);

        public Task<Bodega> FindAsync(int id);

        public Task<IEnumerable<Bodega>> GetAllAsync();
    }
}
