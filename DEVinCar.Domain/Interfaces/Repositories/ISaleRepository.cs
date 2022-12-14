using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ISaleRepository : IBaseRepository<Sale, int>
    {
 
        IList<Sale> BuyerByID(int sellerid);
        IList<Sale> SellerByID(int buyerid);
    }
    
}