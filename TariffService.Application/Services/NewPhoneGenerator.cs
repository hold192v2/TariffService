using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Application.Services
{
    public static class NewPhoneGenerator
    {
        private static readonly string[] prefixes = { "467", "542", "734" };
        private static readonly Random random = new Random();
        public static string GeneratePhoneNumber()
        {
            string prefix = prefixes[random.Next(prefixes.Length)];
            string suffix = random.Next(0, 10000000).ToString("D7");
            return $"+7{prefix}{suffix}";
        }
    }
}
