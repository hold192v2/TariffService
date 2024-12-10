using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.Entities
{
<<<<<<< HEAD
    public class MainService : BaseEntity
=======
    public class MainService
>>>>>>> 0d57709 (Добавьте файлы проекта.)
    {
        public int Id { get; set; }
        public Dictionary<string, ServiceBase> BasicServices { get; set; } = new();
        public Dictionary<string, ServiceBase> UnlimitedApps { get; set; } = new();
        public Dictionary<string, ServiceBase> ExtraServices { get; set; } = new();
    }
}
