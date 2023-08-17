using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IEnvioRepository
    {
        public Task<Envio> AddAsync(Envio envio);

        public Task<Envio> UpdateAsync(int id, Envio envio);

        public Task<Envio> RemoveAsync(int id);

        public Task<Envio> FindAsync(int id);

        public Task<IEnumerable<Envio>> GetAllAsync();
    }
}
