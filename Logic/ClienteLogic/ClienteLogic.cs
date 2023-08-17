using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.ClienteLogic
{
    public class ClienteLogic : IClienteLogic
    {
        private readonly IMapper _mapper;

        private readonly IClienteRepository _clienteRepository;


        public ClienteLogic(IMapper mapper, IClienteRepository clienteRepository)
        {
            this._mapper = mapper;
            this._clienteRepository = clienteRepository;
        }
        public async Task<ClienteDto> AddAsync(ClienteDto clienteDto)
        {
            var entity = await _clienteRepository.AddAsync(_mapper.Map<Cliente>(clienteDto));

            var result = _mapper.Map<ClienteDto>(entity);

            return result;
        }

        public async Task<ClienteDto> FindAsync(int id)
        {
            var entity = await _clienteRepository.FindAsync(id);

            var result = _mapper.Map<ClienteDto>(entity);

            return result;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var entities = await _clienteRepository.GetAllAsync();

            var result = _mapper.Map<List<ClienteDto>>(entities);

            return result;
        }

        public async Task<ClienteDto> RemoveAsync(int id)
        {
            var entity = await _clienteRepository.RemoveAsync(id);

            var result = _mapper.Map<ClienteDto>(entity);

            return result;
        }

        public async Task<ClienteDto> UpdateAsync(int id, ClienteDto clienteDto)
        {
            var entity = await _clienteRepository.UpdateAsync(id, _mapper.Map<Cliente>(clienteDto));

            var result = _mapper.Map<ClienteDto>(entity);

            return result;
        }
    }
}
