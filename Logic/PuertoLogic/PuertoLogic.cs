using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.PuertoLogic
{
    public class PuertoLogic : IPuertoLogic
    {
        private readonly IMapper _mapper;

        private readonly IPuertoRepository _puertoRepository;


        public PuertoLogic(IMapper mapper, IPuertoRepository puertoRepository)
        {
            this._mapper = mapper;
            this._puertoRepository = puertoRepository;
        }
        public async Task<PuertoDto> AddAsync(PuertoDto puertoDto)
        {
            var entity = await _puertoRepository.AddAsync(_mapper.Map<Puerto>(puertoDto));

            var result = _mapper.Map<PuertoDto>(entity);

            return result;
        }

        public async Task<PuertoDto> FindAsync(int id)
        {
            var entity = await _puertoRepository.FindAsync(id);

            var result = _mapper.Map<PuertoDto>(entity);

            return result;
        }

        public async Task<IEnumerable<PuertoDto>> GetAllAsync()
        {
            var entities = await _puertoRepository.GetAllAsync();

            var result = _mapper.Map<List<PuertoDto>>(entities);

            return result;
        }

        public async Task<PuertoDto> RemoveAsync(int id)
        {
            var entity = await _puertoRepository.RemoveAsync(id);

            var result = _mapper.Map<PuertoDto>(entity);

            return result;
        }

        public async Task<PuertoDto> UpdateAsync(int id, PuertoDto puertoDto)
        {
            var entity = await _puertoRepository.UpdateAsync(id, _mapper.Map<Puerto>(puertoDto));

            var result = _mapper.Map<PuertoDto>(entity);

            return result;
        }
    }
}
