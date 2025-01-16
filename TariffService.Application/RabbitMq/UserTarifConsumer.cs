using AutoMapper;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.DTOs;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;

namespace TariffService.Application.RabbitMq
{
    public class UserTarifConsumer : IConsumer<GetTariffInfoDTO>
    {
        private readonly ITariffCart _tariffCart;
        private readonly IMapper _mapper;
        private readonly IStaticTariffInterface _staticTariffInterface;
        private readonly IDynamicTariff _dynamicTariffInterface; 

        public UserTarifConsumer(ITariffCart tariffCart, IMapper mapper, IStaticTariffInterface staticTariffInterface, IDynamicTariff dynamicTariff)
        {
            _tariffCart = tariffCart;
            _mapper = mapper;
            _staticTariffInterface = staticTariffInterface;
            _dynamicTariffInterface = dynamicTariff;
        }

        public async Task Consume(ConsumeContext<GetTariffInfoDTO> context)
        {
            var temporaryId = context.Message.TariffId;
            var tariffType = GetTariffType(temporaryId);
            var tariff = new Tariff();
            if (tariffType == "Static")
            {
                var staticTariff = await _staticTariffInterface.GetByNumberId(temporaryId);
                tariff = _mapper.Map<Tariff>(staticTariff);
            }
            else if (tariffType == "Dynamic")
            {
                var dynamicTariff = await _dynamicTariffInterface.GetByHashId(temporaryId);
                tariff = _mapper.Map<Tariff>(dynamicTariff);
            }
            // Ищем пользователя по номеру телефона

            if (tariff != null)
            {
                await context.RespondAsync(tariff);
            }
            else
            {
                await context.RespondAsync<Tariff>(null);
            }
        }
        public static string GetTariffType(string id)
        {
            if (Guid.TryParse(id, out _))
            {
                return "Static";
            }
            else if (IsBase64String(id))
            {
                return "Dynamic";
            }
            else
            {
                throw new ArgumentException("Invalid tariff id format");
            }
        }

        private static bool IsBase64String(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
                return false;
            if (base64.Length % 4 != 0)
                return false;
            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
