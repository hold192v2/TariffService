using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.Entities
{
    public class MainService
    {
        public int Id { get; set; }
        public Dictionary<string, ServiceBase> BasicServices { get; set; } = new();
        public Dictionary<string, ServiceBase> UnlimitedApps { get; set; } = new();
        public Dictionary<string, ServiceBase> ExtraServices { get; set; } = new();
    }
}
