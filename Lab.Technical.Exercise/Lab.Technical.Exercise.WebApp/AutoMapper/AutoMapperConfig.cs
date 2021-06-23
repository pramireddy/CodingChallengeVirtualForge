using AutoMapper;
using Lab.Technical.Exercise.DataContracts;
using Lab.Technical.Exercise.DataContracts.Enums;
using Lab.Technical.Exercise.Domain.EntityModels;
using System;

namespace Lab.Technical.Exercise.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Domain.EntityModels.Album, DataContracts.Album>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(source => Enum.GetName(typeof(AlbumType), source.AlbumType)));

            CreateMap<Domain.EntityModels.Artist, DataContracts.Artist>();
            CreateMap<Domain.EntityModels.Label, DataContracts.Label>();
            CreateMap<Domain.EntityModels.Stock, DataContracts.Stock>();
        }
    }
}