using DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.EnvioLogic
{
    public interface IEnvioLogic
    {
        public Task<EnvioDto> AddAsync(EnvioDto envioDto);

        public Task<EnvioDto> UpdateAsync(int id, EnvioDto envioDto);

        public Task<EnvioDto> RemoveAsync(int id);

        public Task<IEnumerable<EnvioDto>> GetAllAsync();

        public Task<EnvioDto> FindAsync(int id);
    }
}
