using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class SaleRepository : BaseRepository<Sale, int>, ISaleRepository
    {
        public SaleRepository(DevInCarDbContext context) : base(context)
        {
        }
        public IList<Sale> SellerByID(int buyerid){
            var seller = _context.Sales.Where(s => s.BuyerId == buyerid);
            return seller.ToList();
        }
         public IList<Sale> BuyerByID(int sellerid){
            var seller = _context.Sales.Where(s => s.SellerId == sellerid);
            return seller.ToList();
        }

    }
}