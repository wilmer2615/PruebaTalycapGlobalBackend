using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.BodegaLogic
{
    public class BodegaLogic : IBodegaLogic
    {
        private readonly IMapper _mapper;

        private readonly IBodegaRepository _bodegaRepository;


        public BodegaLogic(IMapper mapper, IBodegaRepository bodegaRepository)
        {
            this._mapper = mapper;
            this._bodegaRepository = bodegaRepository;
        }
        public async Task<BodegaDto> AddAsync(BodegaDto bodegaDto)
        {
            var entity = await _bodegaRepository.AddAsync(_mapper.Map<Bodega>(bodegaDto));

            var result = _mapper.Map<BodegaDto>(entity);

            return result;
        }

        public async Task<BodegaDto> FindAsync(int id)
        {
            var entity = await _bodegaRepository.FindAsync(id);

            var result = _mapper.Map<BodegaDto>(entity);

            return result;
        }

        public async Task<IEnumerable<BodegaDto>> GetAllAsync()
        {
            var entities = await _bodegaRepository.GetAllAsync();

            var result = _mapper.Map<List<BodegaDto>>(entities);

            return result;
        }

        public async Task<BodegaDto> RemoveAsync(int id)
        {
            var entity = await _bodegaRepository.RemoveAsync(id);

            var result = _mapper.Map<BodegaDto>(entity);

            return result;
        }

        public async Task<BodegaDto> UpdateAsync(int id, BodegaDto bodegaDto)
        {
            var entity = await _bodegaRepository.UpdateAsync(id, _mapper.Map<Bodega>(bodegaDto));

            var result = _mapper.Map<BodegaDto>(entity);

            return result;
        }
    }
}
