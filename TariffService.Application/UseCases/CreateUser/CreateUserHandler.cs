using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.HadlerResponse;
using TariffService.Application.Services;
using TariffService.Application.UseCases.CartUseCases.SaveTariffCart;
using TariffService.Domain.Interfaces;

namespace TariffService.Application.UseCases.UpdateUserTariff
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, Response>
    {
        private readonly ITariffCart _tariffCart;
        public CreateUserHandler( ITariffCart tariffCart)
        {
            _tariffCart = tariffCart;
        }
        public async Task<Response> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return new Response("User tariff changed", 200);
        }
    }//ТУТ НАДО ПИХАТЬ SENDER ОБЯЗАТЕЛЬНО!!!!
}
