using AutoMapper;
using DataTransferObjects;
using Entities;
using System;

namespace Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Bodega
            /// *************************************************** 
            CreateMap<BodegaDto, Bodega>()
                .ReverseMap();            

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Cliente
            /// *************************************************** 
            CreateMap<ClienteDto, Cliente>()
                .ReverseMap();
            
            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Envio
            /// *************************************************** 
            CreateMap<EnvioDto, Envio>()
                .ReverseMap();            

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad EnvioMaritimo
            /// *************************************************** 
            CreateMap<EnvioMaritimoDto, EnvioMaritimo>()
                .ReverseMap();
            
            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad EnvioTerrestre
            /// *************************************************** 
            CreateMap<EnvioTerrestreDto, EnvioTerrestre>()
                .ReverseMap();

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Producto
            /// *************************************************** 
            CreateMap<ProductoDto, Producto>()
                .ReverseMap();

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Puerto
            /// *************************************************** 
            CreateMap<PuertoDto, Puerto>()
                .ReverseMap();


        }
    }
}
