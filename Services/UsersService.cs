using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetUserById(int id)
        {
            var user = _usersRepository.GetUserById(id);

            return user.ToDomain();
        }

        public User GetUserByLoginPassword(string login, string password)
        {
            var user = _usersRepository.GetUserByLoginPassword(login, password);

            return user.ToDomain();
        }
    }
}
