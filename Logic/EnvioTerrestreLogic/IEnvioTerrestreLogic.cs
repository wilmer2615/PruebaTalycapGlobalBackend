using DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.EnvioTerrestreLogic
{
    public interface IEnvioTerrestreLogic
    {
        public Task<EnvioTerrestreDto> AddAsync(EnvioTerrestreDto envioTerrestreDto);

        public Task<EnvioTerrestreDto> UpdateAsync(int id, EnvioTerrestreDto envioTerrestreDto);

        public Task<EnvioTerrestreDto> RemoveAsync(int id);

        public Task<IEnumerable<EnvioTerrestreDto>> GetAllAsync();

        public Task<EnvioTerrestreDto> FindAsync(int id);
    }
}
