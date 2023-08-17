using DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.ClienteLogic
{
    public interface IClienteLogic
    {
        public Task<ClienteDto> AddAsync(ClienteDto clienteDto);

        public Task<ClienteDto> UpdateAsync(int id, ClienteDto clienteDto);

        public Task<ClienteDto> RemoveAsync(int id);

        public Task<IEnumerable<ClienteDto>> GetAllAsync();

        public Task<ClienteDto> FindAsync(int id);
    }
}
