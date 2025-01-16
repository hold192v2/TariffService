using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.DTOs;
using TariffService.Domain.DTO;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;
using TariffService.Infrastructure.Context;

namespace TariffService.Infrastructure.Repositories
{
    public class TariffCartRepository : BaseRepository<TariffCart>, ITariffCart
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public TariffCartRepository(AppDbContext appDbContext, IMapper mapper) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<List<TariffCartDTO>> GetAllUserTariffCart(Guid userId)
        {
            var tariffCarts = await _appDbContext.TariffCarts.Where(tariff => tariff.TempUserId == userId).ToListAsync();
            var list = new List<TariffCartDTO>();
            foreach (var cart in tariffCarts)
            {
                if (GetTariffType(cart.TariffId) == "Static")
                {
                    var staticTariff = await _appDbContext.StaticTariffs.FirstOrDefaultAsync(x => x.Id == Guid.Parse(cart.TariffId));
                    var tariff = _mapper.Map<Tariff>(staticTariff);
                    var cartDto = new TariffCartDTO()
                    {
                        UserId = cart.TempUserId,
                        CardId = cart.Id,
                        Tarriff = tariff,
                        NewPhone = cart.NewPhone,
                    };
                    list.Add(cartDto);
                }
                else if (GetTariffType(cart.TariffId) == "Dynamic")
                {
                    var dynamicTariff = await _appDbContext.DynamicTariffs.FirstOrDefaultAsync(x => x.Id == cart.TariffId);
                    var tariff = _mapper.Map<Tariff>(dynamicTariff);
                    var cartDto = new TariffCartDTO()
                    {
                        UserId = cart.TempUserId,
                        CardId = cart.Id,
                        Tarriff = tariff,
                        NewPhone = cart.NewPhone,
                    };
                    list.Add(cartDto);
                }
            }
            return list;
        }

        public async Task<List<CreateCartDTO>> GetAllUserTariff(Guid userId, Guid temporaryUserId)
        {
            var tariffCarts = await _appDbContext.TariffCarts.Where(tariff => tariff.TempUserId == userId).ToListAsync();

            var list = new List<CreateCartDTO>();
            foreach (var cart in tariffCarts)
            {
                if (GetTariffType(cart.TariffId) == "Static")
                {
                    var staticTariff = await _appDbContext.StaticTariffs.FirstOrDefaultAsync(x => x.Id == Guid.Parse(cart.TariffId));
                    var tariff = _mapper.Map<Tariff>(staticTariff);
                    var cartDto = new CreateCartDTO()
                    {

                        AbonentId = userId,
                        TariffId = cart.TariffId,
                        TariffCost = tariff.Price,
                        PhoneNumber = cart.NewPhone,
                    };
                    list.Add(cartDto);
                }
                else if (GetTariffType(cart.TariffId) == "Dynamic")
                {
                    var dynamicTariff = await _appDbContext.DynamicTariffs.FirstOrDefaultAsync(x => x.Id == cart.TariffId);
                    var tariff = _mapper.Map<Tariff>(dynamicTariff);
                    var cartDto = new CreateCartDTO()
                    {
                        AbonentId = userId,
                        TariffId = cart.TariffId,
                        TariffCost = tariff.Price,
                        PhoneNumber = cart.NewPhone,
                    };
                    list.Add(cartDto);
                }
            }
            return list;
        }

        public Task<int> GetCartCount(Guid userId)
        {
            return _appDbContext.TariffCarts.Where(tariff => tariff.TempUserId == userId).CountAsync();
        }

        public async Task DeleteById(Guid cardId, Guid userId)
        {
            var tariffCart = await _appDbContext.TariffCarts
        .FirstOrDefaultAsync(cart => cart.Id == cardId && cart.TempUserId == userId);
            if (tariffCart == null)
            {
                throw new KeyNotFoundException("The specified tariff cart was not found.");
            }
            Delete(tariffCart);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAll(Guid userId)
        {
            var tariffCarts = await _appDbContext.TariffCarts
            .Where(cart => cart.TempUserId == userId)
            .ToListAsync();

            _appDbContext.TariffCarts.RemoveRange(tariffCarts);
            await _appDbContext.SaveChangesAsync();
        }




        private static string GetTariffType(string id)
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
