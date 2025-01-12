using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.UseCases.CreateStaticTariff;
using TariffService.Application.UseCases.GetStaticTarrifs;
using TariffService.Domain.Entities;
using TariffService.Domain.Requests;

namespace TariffService.Application.Mappers
{
    public class StaticTariffReuestMapper : Profile
    {
        public StaticTariffReuestMapper()
        {
            {
                CreateMap<StaticTariffsRequest, GetStaticTariffsRequest>().ReverseMap();
            }
        }
    }
}
