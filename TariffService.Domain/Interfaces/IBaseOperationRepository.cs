using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;

namespace TariffService.Domain.Interfaces
{
    public interface IBaseOperationRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}
