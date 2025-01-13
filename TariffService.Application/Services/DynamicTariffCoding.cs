using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.DTOs;

namespace TariffService.Application.Services
{
    public static class DynamicTariffCoding
    {
        public static string EncodeDynamicTariff(DynamicTariffDTO dynamicTariff)
        {
            // Формируем строку с данными
            string tariffData = $"{dynamicTariff.Gigabytes}-{dynamicTariff.Minutes}-{dynamicTariff.Sms}-{dynamicTariff.UnlimVideo}-{dynamicTariff.UnlimSocials}-{dynamicTariff.UnlimMusic}-{dynamicTariff.LongDistanceCall}";

            // Кодируем строку в Base64
            string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(tariffData));

            return base64String;
        }

        public static string DecodeDynamicTariff(string base64String)
        {
            // Декодируем строку из Base64
            string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
            return decodedString;
        }
    }
}
