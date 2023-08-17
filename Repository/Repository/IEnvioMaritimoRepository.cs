using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IEnvioMaritimoRepository
    {
        public Task<EnvioMaritimo> AddAsync(EnvioMaritimo envioMaritimo);

        public Task<EnvioMaritimo> UpdateAsync(int id, EnvioMaritimo envioMaritimo);

        public Task<EnvioMaritimo> RemoveAsync(int id);

        public Task<EnvioMaritimo> FindAsync(int id);

        public Task<IEnumerable<EnvioMaritimo>> GetAllAsync();
    }
}
