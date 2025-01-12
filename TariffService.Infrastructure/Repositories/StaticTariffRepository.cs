using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;
using TariffService.Domain.Requests;
using TariffService.Infrastructure.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TariffService.Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностью StaticTariff.
    /// Наследуется от базового репозитория и реализует интерфейс IStaticTariffInterface.
    /// </summary>
    public class StaticTariffRepository : BaseRepository<StaticTariff>, IStaticTariffInterface
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор репозитория. Принимает экземпляр контекста базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public StaticTariffRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод для получения StaticTariff по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор StaticTariff.</param>
        /// <returns>StaticTariff или null, если не найден.</returns>
        public async Task<StaticTariff?> GetByNumberId(int id, CancellationToken cancellationToken)
        {
            return  _context.StaticTariffs.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Метод для фильтрации и пагинации тарифов на основе переданных параметров запроса.
        /// </summary>
        /// <param name="request">Объект запроса с параметрами фильтрации.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Список отфильтрованных и пагинированных тарифов.</returns>
        public async Task<List<StaticTariff>> GetPaginationAndFilterTariffs(StaticTariffsRequest request, CancellationToken cancellationToken)
        {
            // Создание базового запроса для таблицы StaticTariff.
            var query = _context.Set<StaticTariff>().AsQueryable();

            // Применение фильтров, если значения заданы.
            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(t => t.Name == request.Name);

            if (request.Price.HasValue)
                query = query.Where(t => t.Price == request.Price.Value);

            if (request.Minutes.HasValue)
                query = query.Where(t => t.Minutes == request.Minutes.Value);

            if (request.Gigabytes.HasValue)
                query = query.Where(t => t.Gigabytes == request.Gigabytes.Value);

            if (request.Sms.HasValue)
                query = query.Where(t => t.Sms == request.Sms.Value);

            if (request.UnlimVideo.HasValue)
                query = query.Where(t => t.UnlimVideo == request.UnlimVideo.Value);

            if (request.UnlimSocials.HasValue)
                query = query.Where(t => t.UnlimSocials == request.UnlimSocials.Value);

            if (request.UnlimMusic.HasValue)
                query = query.Where(t => t.UnlimMusic == request.UnlimMusic.Value);

            if (request.LongDistanceCall.HasValue)
                query = query.Where(t => t.LongDistanceCall == request.LongDistanceCall.Value);

            if (request.Status.HasValue)
                query = query.Where(t => t.Status == request.Status.Value);

            // Подсчет общего количества элементов (для возможного отображения метаданных).
            var totalCount = await query.CountAsync(cancellationToken);

            // Применение пагинации (размер страницы - 20).
            var items = await query
                .Skip((request.PageNumber - 1) * 20)
                .Take(20)
                .ToListAsync(cancellationToken);

            // Возврат отфильтрованного и пагинированного списка тарифов.
            return items;
        }
    }
}
