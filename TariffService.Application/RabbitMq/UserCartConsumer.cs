using MassTransit;
using ServiceAbonents.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.DTOs;
using TariffService.Domain.Interfaces;

namespace TariffService.Application.RabbitMq
{
    public class UserCartConsumer : IConsumer<IdForCartDto>
    {
        private readonly ITariffCart _tariffCart;

        public UserCartConsumer(ITariffCart tariffCart)
        {
            _tariffCart = tariffCart;
        }

        public async Task Consume(ConsumeContext<IdForCartDto> context)
        {
            var temporaryId = context.Message.TemporaryId;

            // Ищем пользователя по номеру телефона
            var listCart = await _tariffCart.GetAllUserTariffCart(temporaryId);

            if (listCart != null)
            {
                var transerCartList = new ListTransferDataAbonentDto() { tariffCartDTOs = listCart};
                await context.RespondAsync(listCart);
            }
            else
            {
                await context.RespondAsync<ListTransferDataAbonentDto>(null);
            }
        }

    }
}
