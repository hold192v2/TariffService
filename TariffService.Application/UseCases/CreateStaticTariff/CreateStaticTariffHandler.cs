using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.HadlerResponse;
using TariffService.Application.UseCases.GetStaticTarrifs;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;

namespace TariffService.Application.UseCases.CreateStaticTariff
{
    public class CreateStaticTariffHandler : IRequestHandler<CreateStaticTariffRequest, Response>
    {
        private readonly IMapper _mapper;
        private readonly IStaticTariffInterface _staticInterface;
        private readonly IUnitOfWork _unitOfWork;
        public CreateStaticTariffHandler(IMapper mapper, IStaticTariffInterface staticTariffInterface, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _staticInterface = staticTariffInterface;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> Handle(CreateStaticTariffRequest request, CancellationToken cancellationToken)
        {
            var staticTariff = _mapper.Map<StaticTariff>(request);
            try
            {
                _staticInterface.Create(staticTariff);
                await _unitOfWork.Commit(cancellationToken);
            }
            catch
            {
                return new Response("Internal Server Error", 500);
            }
            return new Response("Tariff created", 200);

        }
    }
}
