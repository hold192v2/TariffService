using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.HadlerResponse;
using TariffService.Application.Services;
using TariffService.Application.UseCases.GetStaticTarrifs;
using TariffService.Domain.Interfaces;

namespace TariffService.Application.UseCases.CartUseCases.SaveTariffCart
{
    public class SaveTariffCartHandler : IRequestHandler<SaveTariffCartRequest, Response>
    {
        private readonly ITariffCart _tariffCart;
        private readonly IUnitOfWork _unitOfWork;
        public SaveTariffCartHandler(IUnitOfWork unitOfWork, ITariffCart tariffCart)
        {
            _tariffCart = tariffCart;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> Handle(SaveTariffCartRequest request, CancellationToken cancellationToken)
        {
            if (request.tariff is null)
            {
                var newCart = new TariffCart(request.userId, request.staticTariffId, NewPhoneGenerator.GeneratePhoneNumber());
                _tariffCart.Create(newCart);
            }
            else if (request.staticTariffId is null)
            {
                var tariffId = DynamicTariffCoding.EncodeDynamicTariff(request.tariff);
                var newCart = new TariffCart(request.userId, tariffId, NewPhoneGenerator.GeneratePhoneNumber());
            }
            else
            {
                return new Response("Iternal server error", 500);
            }
            await _unitOfWork.Commit(cancellationToken);

            var countCart = await _tariffCart.GetCartCount(request.userId);
            return new Response("Cart is created", 200, countCart);

        }
    }
}
