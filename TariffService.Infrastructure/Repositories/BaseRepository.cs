using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;
using TariffService.Infrastructure.Context;

namespace TariffService.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseOperationRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Create(T entity)
        {
            appDbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            appDbContext.Remove(entity);
        }

        public List<T> GetAll()
        {
            return appDbContext.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            appDbContext.Update(entity);
        }
    }
}
