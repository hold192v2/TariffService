using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;
using TariffService.Infrastructure.Context;
using TariffService.Infrastructure.Repositories;

public class UnitPriceRepository : BaseRepository<UnitPrice>, IUnitPrice
{
    private readonly AppDbContext _context;

    public UnitPriceRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    
}