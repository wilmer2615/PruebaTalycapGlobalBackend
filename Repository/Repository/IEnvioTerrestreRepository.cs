using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IEnvioTerrestreRepository
    {
        public Task<EnvioTerrestre> AddAsync(EnvioTerrestre envioTerrestre);

        public Task<EnvioTerrestre> UpdateAsync(int id, EnvioTerrestre envioTerrestre);

        public Task<EnvioTerrestre> RemoveAsync(int id);

        public Task<EnvioTerrestre> FindAsync(int id);

        public Task<IEnumerable<EnvioTerrestre>> GetAllAsync();
    }
}
