using TariffService.Application.DTOs;
using TariffService.Application.Services;
using TariffService.Domain.Entities;

namespace TariffService.Services
{
    public static class DynamicTariffGenerate
    {
        public static List<DynamicTariff> GenerateTariffs()
        {
            var gigabytes = new[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            var minutes = new[] { 250, 350, 500, 700, 900, 1500, 2000 };
            var sms = new[] { 50, 100, 200, 300, 400, 500 };
            var boolOptions = new[] { true, false };

            var tariffs = new List<DynamicTariff>();

            foreach (var gb in gigabytes)
            {
                foreach (var min in minutes)
                {
                    foreach (var sm in sms)
                    {
                        foreach (var unlimVideo in boolOptions)
                        {
                            foreach (var unlimSocials in boolOptions)
                            {
                                foreach (var unlimMusic in boolOptions)
                                {
                                    foreach (var longDistanceCall in boolOptions)
                                    {
                                        var dto = new DynamicTariffDTO
                                        {
                                            Gigabytes = gb,
                                            Minutes = min,
                                            Sms = sm,
                                            UnlimVideo = unlimVideo,
                                            UnlimSocials = unlimSocials,
                                            UnlimMusic = unlimMusic,
                                            LongDistanceCall = longDistanceCall
                                        };

                                        var tariff = new DynamicTariff
                                        {
                                            Id = DynamicTariffCoding.EncodeDynamicTariff(dto),
                                            Name = "Личный",
                                            Price = CalculatePrice(dto), 
                                            Gigabytes = gb,
                                            Minutes = min,
                                            Sms = sm,
                                            UnlimVideo = unlimVideo,
                                            UnlimSocials = unlimSocials,
                                            UnlimMusic = unlimMusic,
                                            LongDistanceCall = longDistanceCall,
                                            Status = true
                                        };

                                        tariffs.Add(tariff);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return tariffs;
        }
        private static decimal CalculatePrice(DynamicTariffDTO tariff)
        {
            // Базовая цена минимального тарифа
            decimal basePrice = 210;

            // Разница в параметрах
            decimal additionalPrice = 0;
            additionalPrice += (tariff.Gigabytes - 5) * 6; // 1 ГБ = 6 рублей
            additionalPrice += (tariff.Minutes - 250) * 0.6m; // 1 минута = 0.6 рублей
            additionalPrice += (tariff.Sms - 50) * 0.6m; // 1 смс = 0.6 рублей

            // Услуги
            additionalPrice += tariff.UnlimVideo ? 80 : 0;
            additionalPrice += tariff.UnlimSocials ? 100 : 0;
            additionalPrice += tariff.UnlimMusic ? 60 : 0;
            additionalPrice += tariff.LongDistanceCall ? 60 : 0;

            return basePrice + additionalPrice;
        }
    }
}
