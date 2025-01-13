using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.DTOs;
using TariffService.Application.UseCases.GetStaticTarrifs;
using TariffService.Domain.Entities;
using TariffService.Domain.Requests;

namespace TariffService.Application.Mappers
{
    public class TariffMapper : Profile
    {
        public TariffMapper()
        {
            {
                CreateMap<StaticTariff, Tariff>();
                CreateMap<DynamicTariff, Tariff>();
            }
        }
    }
}
