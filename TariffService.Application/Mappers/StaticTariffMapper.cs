using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.UseCases.CreateStaticTariff;
using TariffService.Domain.Entities;

namespace TariffService.Application.Mappers
{
    public class StaticTariffMapper : Profile
    {
        public StaticTariffMapper() 
        {
            CreateMap<CreateStaticTariffRequest, StaticTariff>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Игнорируем Id при маппинге
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .ForMember(dest => dest.ImageUrl2, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}
