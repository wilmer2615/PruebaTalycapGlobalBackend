using DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.EnvioMaritimoLogic
{
    public interface IEnvioMaritimoLogic
    {
        public Task<EnvioMaritimoDto> AddAsync(EnvioMaritimoDto envioMaritimoDto);

        public Task<EnvioMaritimoDto> UpdateAsync(int id, EnvioMaritimoDto envioMaritimoDto);

        public Task<EnvioMaritimoDto> RemoveAsync(int id);

        public Task<IEnumerable<EnvioMaritimoDto>> GetAllAsync();

        public Task<EnvioMaritimoDto> FindAsync(int id);
    }
}
