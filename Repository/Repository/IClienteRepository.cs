using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IClienteRepository
    {
        public Task<Cliente> AddAsync(Cliente cliente);

        public Task<Cliente> UpdateAsync(int id, Cliente cliente);

        public Task<Cliente> RemoveAsync(int id);

        public Task<Cliente> FindAsync(int id);

        public Task<IEnumerable<Cliente>> GetAllAsync();
    }
}
