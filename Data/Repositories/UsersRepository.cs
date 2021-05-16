using Data.Repositories.Abstract;
using Entities;
using EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UsersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public UserEntity GetUserById(int id)
        {
            var user = _databaseContext.Users
                .FirstOrDefault(x => x.Id.Equals(id));

            return user;
        }

        public UserEntity GetUserByLoginPassword(string login, string password)
        {
            UserEntity user = _databaseContext.Users
                .FirstOrDefault(u => u.Login.Equals(login));

            if (user is not null)
            {
                PasswordHasher<UserEntity> hasher = new PasswordHasher<UserEntity>();

                PasswordVerificationResult result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

                return result == PasswordVerificationResult.Failed ? null : user;
            }

            return user;
        }
    }
}
