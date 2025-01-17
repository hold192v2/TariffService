using AutoMapper;
using ServiceAbonents.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;

namespace TariffService.Application.Mappers
{
    public class TarifftoDtoMapper : Profile
    {
        public TarifftoDtoMapper()
        {
            {
                CreateMap<Tariff, TariffDto>()
                    .ForMember(dest => dest.TariffName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.RemainGb, opt => opt.MapFrom(src => src.Gigabytes))
                    .ForMember(dest => dest.RemainMin, opt => opt.MapFrom(src => src.Minutes))
                    .ForMember(dest => dest.RemainSMS, opt => opt.MapFrom(src => src.Sms));
            }
        }
    }
}
