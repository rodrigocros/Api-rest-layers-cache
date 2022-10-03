using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISaleRepository _saleRepository;

        public UserService(IUserRepository userRepository,ISaleRepository saleRepository )
        {
            _userRepository = userRepository;
            _saleRepository = saleRepository;
        }

        public void Excluir(User user)
        {
            _userRepository.Excluir(user);
        }

        public IList<User> Get(string Name,DateTime? birthDateMax,DateTime? birthDateMin)
        {
            var query = _userRepository.Query();

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(c => c.Name.Contains(Name));
            }

            if (birthDateMin.HasValue)
            {
                query = query.Where(c => c.BirthDate >= birthDateMin.Value);
            }

            if (birthDateMax.HasValue)
            {
                query = query.Where(c => c.BirthDate <= birthDateMax.Value);
            }

            return query.ToList();
        }

        public User GetById(int id)
        {
            return _userRepository.ObterPorID(id);

        }

        public void Inserir(User user)
        {
            var oldUser = _userRepository.GetByEmail(user.Email);

            if (oldUser != null)
            {
                throw new JaExisteException("Email ja cadastrado");
            }

            _userRepository.Inserir(user);
        }

        public IList<Sale> GetSellerByID(int sellerId){
            
            return _saleRepository.SellerByID(sellerId);
            
        }
        public IList<Sale> GetBuyerByID(int buyerId){
            
            var buyer = _saleRepository.BuyerByID(buyerId);
            return buyer;
        }
    }
}