using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IPuertoRepository
    {
        public Task<Puerto> AddAsync(Puerto puerto);

        public Task<Puerto> UpdateAsync(int id, Puerto puerto);

        public Task<Puerto> RemoveAsync(int id);

        public Task<Puerto> FindAsync(int id);

        public Task<IEnumerable<Puerto>> GetAllAsync();
    }
}
