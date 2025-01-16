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

namespace TariffService.Application.UseCases.UpdateStaticTariffs
{
    public class UpdateStaticTariffHandler : IRequestHandler<UpdateStaticTariffRequest, Response>
    {
        private readonly IStaticTariffInterface _staticInterface;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStaticTariffHandler(IStaticTariffInterface staticInterface, IUnitOfWork unitOfWork)
        {

            _staticInterface = staticInterface;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> Handle(UpdateStaticTariffRequest request, CancellationToken cancellationToken)
        {
            var tariff = await _staticInterface.GetByNumberId(request.Id);
            if (tariff == null)
            {
                return new Response("Internal server error", 500); // Сущность не найдена
            }
            tariff.Name = request.Name;
            tariff.Price = request.Price;
            tariff.Minutes = request.Minutes;
            tariff.Gigabytes = request.Gigabytes;
            tariff.Sms = request.Sms;
            tariff.UnlimVideo = request.UnlimVideo;
            tariff.UnlimSocials = request.UnlimSocials;
            tariff.UnlimMusic = request.UnlimMusic;
            tariff.LongDistanceCall = request.LongDistanceCall;
            tariff.Status = request.Status;
            tariff.ImageUrl = request.ImageUrl;
            tariff.ImageUrl2 = request.ImageUrl2;

            await _unitOfWork.Commit(cancellationToken);
            return new Response("OK", 200);
        }
    }
}
