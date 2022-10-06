using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IQueryable<User> Get(string Name,DateTime? birthDateMax,DateTime? birthDateMin);
        User GetById(int id);
        void Inserir(User user);
        void Excluir (User user);
        IList<Sale> GetSellerByID(int buyerid);
        IList<Sale> GetBuyerByID(int buyerId);
        User ObterPorUsuarioESenha(UserLoginDTO userloginDTO);


    }
}