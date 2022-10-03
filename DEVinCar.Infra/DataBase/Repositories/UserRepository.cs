using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DevInCarDbContext context) : base(context)
        {
        }
        public User GetByEmail(String email){
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public User GetByEmailPassword(UserLoginDTO userloginDTO){
            var user =  _context.Users.FirstOrDefault(u => u.Email == userloginDTO.Email && u.Password == userloginDTO.Password);
            return user;
        }
    }
}