using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EnvioLogic
{
    public class EnvioLogic : IEnvioLogic
    {
        private readonly IMapper _mapper;
        private readonly IEnvioRepository _envioRepository;
        private readonly IEnvioMaritimoRepository _envioMaritimoRepository;
        private readonly IEnvioTerrestreRepository _envioTerrestreRepository;




        public EnvioLogic(IMapper mapper, IEnvioRepository envioRepository, IEnvioMaritimoRepository envioMaritimoRepository,
            IEnvioTerrestreRepository envioTerrestreRepository)

        {
            this._mapper = mapper;
            this._envioRepository = envioRepository;
            this._envioMaritimoRepository = envioMaritimoRepository;
            this._envioTerrestreRepository = envioTerrestreRepository;

        }
        public async Task<EnvioDto> AddAsync(EnvioDto envioDto)
        {
            if (envioDto.CantidadProducto > 10 && envioDto.Terrestre == true)
            {
                envioDto.Descuento = (envioDto.PrecioEnvio * 0.05);
            }
            else if (envioDto.CantidadProducto > 10 && envioDto.Maritimo == true)
            {
                envioDto.Descuento = (envioDto.PrecioEnvio * 0.03);
            }

            var entity = await _envioRepository.AddAsync(_mapper.Map<Envio>(envioDto));

            if (entity != null && envioDto.Maritimo)
            {
                var envio = new EnvioMaritimo
                {
                    IdEnvio = entity.Id,
                    IdPuerto = envioDto.IdPuerto,
                    NumeroFlota = envioDto.numeroFlota
                };

                await this._envioMaritimoRepository.AddAsync(envio);
            }
            else if (entity != null && envioDto.Terrestre)
            {
                var envio = new EnvioTerrestre
                {
                    IdEnvio = entity.Id,
                    IdBodega = envioDto.IdBodega,
                    PlacaVehiculo = envioDto.PlacaVehiculo
                };

                await this._envioTerrestreRepository.AddAsync(envio);
            }

            var result = _mapper.Map<EnvioDto>(entity);

            return result;
        }

        public async Task<EnvioDto> FindAsync(int id)
        {
            var entity = await _envioRepository.FindAsync(id);

            var result = _mapper.Map<EnvioDto>(entity);

            return result;
        }

        public async Task<IEnumerable<EnvioDto>> GetAllAsync()
        {
            var entities = await _envioRepository.GetAllAsync();

            var result = _mapper.Map<List<EnvioDto>>(entities);

            return result;
        }

        public async Task<EnvioDto> RemoveAsync(int id)
        {
            var entity = await _envioRepository.RemoveAsync(id);

            var result = _mapper.Map<EnvioDto>(entity);

            return result;
        }

        public async Task<EnvioDto> UpdateAsync(int id, EnvioDto envioDto)
        {
            var entity = await _envioRepository.UpdateAsync(id, _mapper.Map<Envio>(envioDto));

            var result = _mapper.Map<EnvioDto>(entity);

            return result;
        }
    }
}
