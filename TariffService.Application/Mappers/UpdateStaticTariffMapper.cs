using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.UseCases.GetStaticTarrifs;
using TariffService.Application.UseCases.UpdateStaticTariffs;
using TariffService.Domain.Entities;
using TariffService.Domain.Requests;

namespace TariffService.Application.Mappers
{
    public class UpdateStaticTariffMapper : Profile
    {
        public UpdateStaticTariffMapper()
        {
            {
                CreateMap<StaticTariff, UpdateStaticTariffRequest>().ReverseMap();
            }
        }
    }
}
