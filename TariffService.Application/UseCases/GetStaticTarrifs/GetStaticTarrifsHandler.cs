using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.HadlerResponse;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;
using TariffService.Domain.Requests;

namespace TariffService.Application.UseCases.GetStaticTarrifs
{
    public class GetStaticTarrifsHandler : IRequestHandler<GetStaticTariffsRequest, Response>
    {
        private readonly IStaticTariffInterface _staticTariffInterface;
        private readonly IMapper _mapper;
        public GetStaticTarrifsHandler(IStaticTariffInterface staticTariffInterface, IMapper mapper) 
        {
            _staticTariffInterface = staticTariffInterface;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetStaticTariffsRequest request, CancellationToken cancellationToken)
        {
            var tariffs = await _staticTariffInterface.GetPaginationAndFilterTariffs(_mapper.Map<StaticTariffsRequest>(request), cancellationToken);
            return new Response("Tariffs", 200, data: tariffs.Cast<StaticTariff?>().ToList());
            
        }
    }
}
