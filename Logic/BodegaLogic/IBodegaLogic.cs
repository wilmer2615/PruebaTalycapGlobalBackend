using DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.BodegaLogic
{
    public interface IBodegaLogic
    {
        public Task<BodegaDto> AddAsync(BodegaDto bodegaDto);

        public Task<BodegaDto> UpdateAsync(int id, BodegaDto bodegaDto);

        public Task<BodegaDto> RemoveAsync(int id);

        public Task<IEnumerable<BodegaDto>> GetAllAsync();

        public Task<BodegaDto> FindAsync(int id);
    }
}
