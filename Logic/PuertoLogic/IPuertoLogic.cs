using DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.PuertoLogic
{
    public interface IPuertoLogic
    {
        public Task<PuertoDto> AddAsync(PuertoDto puertoDto);

        public Task<PuertoDto> UpdateAsync(int id, PuertoDto puertoDto);

        public Task<PuertoDto> RemoveAsync(int id);

        public Task<IEnumerable<PuertoDto>> GetAllAsync();

        public Task<PuertoDto> FindAsync(int id);
    }
}
