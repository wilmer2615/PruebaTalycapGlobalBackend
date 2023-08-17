using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.EnvioTerrestreLogic
{
    public class EnvioTerrestreLogic : IEnvioTerrestreLogic
    {
        private readonly IMapper _mapper;

        private readonly IEnvioTerrestreRepository _envioTerrestreRepository;


        public EnvioTerrestreLogic(IMapper mapper, IEnvioTerrestreRepository envioTerrestreRepository)
        {
            this._mapper = mapper;
            this._envioTerrestreRepository = envioTerrestreRepository;
        }
        public async Task<EnvioTerrestreDto> AddAsync(EnvioTerrestreDto envioTerrestreDto)
        {
            var entity = await _envioTerrestreRepository.AddAsync(_mapper.Map<EnvioTerrestre>(envioTerrestreDto));

            var result = _mapper.Map<EnvioTerrestreDto>(entity);

            return result;
        }

        public async Task<EnvioTerrestreDto> FindAsync(int id)
        {
            var entity = await _envioTerrestreRepository.FindAsync(id);

            var result = _mapper.Map<EnvioTerrestreDto>(entity);

            return result;
        }

        public async Task<IEnumerable<EnvioTerrestreDto>> GetAllAsync()
        {
            var entities = await _envioTerrestreRepository.GetAllAsync();

            var result = _mapper.Map<List<EnvioTerrestreDto>>(entities);

            return result;
        }

        public async Task<EnvioTerrestreDto> RemoveAsync(int id)
        {
            var entity = await _envioTerrestreRepository.RemoveAsync(id);

            var result = _mapper.Map<EnvioTerrestreDto>(entity);

            return result;
        }

        public async Task<EnvioTerrestreDto> UpdateAsync(int id, EnvioTerrestreDto envioTerrestreDto)
        {
            var entity = await _envioTerrestreRepository.UpdateAsync(id, _mapper.Map<EnvioTerrestre>(envioTerrestreDto));

            var result = _mapper.Map<EnvioTerrestreDto>(entity);

            return result;
        }
    }
}
