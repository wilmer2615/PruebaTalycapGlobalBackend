using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EnvioMaritimoLogic
{
    public class EnvioMaritimoLogic : IEnvioMaritimoLogic
    {
        private readonly IMapper _mapper;

        private readonly IEnvioMaritimoRepository _envioMaritimoRepository;


        public EnvioMaritimoLogic(IMapper mapper, IEnvioMaritimoRepository envioMaritimoRepository)
        {
            this._mapper = mapper;
            this._envioMaritimoRepository = envioMaritimoRepository;
        }
        public async Task<EnvioMaritimoDto> AddAsync(EnvioMaritimoDto envioMaritimoDto)
        {
            var entity = await _envioMaritimoRepository.AddAsync(_mapper.Map<EnvioMaritimo>(envioMaritimoDto));

            var result = _mapper.Map<EnvioMaritimoDto>(entity);

            return result;
        }

        public async Task<EnvioMaritimoDto> FindAsync(int id)
        {
            var entity = await _envioMaritimoRepository.FindAsync(id);

            var result = _mapper.Map<EnvioMaritimoDto>(entity);

            return result;
        }

        public async Task<IEnumerable<EnvioMaritimoDto>> GetAllAsync()
        {
            var entities = await _envioMaritimoRepository.GetAllAsync();

            var result = _mapper.Map<List<EnvioMaritimoDto>>(entities);

            return result;
        }

        public async Task<EnvioMaritimoDto> RemoveAsync(int id)
        {
            var entity = await _envioMaritimoRepository.RemoveAsync(id);

            var result = _mapper.Map<EnvioMaritimoDto>(entity);

            return result;
        }

        public async Task<EnvioMaritimoDto> UpdateAsync(int id, EnvioMaritimoDto envioMaritimoDto)
        {
            var entity = await _envioMaritimoRepository.UpdateAsync(id, _mapper.Map<EnvioMaritimo>(envioMaritimoDto));

            var result = _mapper.Map<EnvioMaritimoDto>(entity);

            return result;
        }
    }
}
