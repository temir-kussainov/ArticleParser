using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IUsersRepository
    {
        UserEntity GetUserById(int id);
        UserEntity GetUserByLoginPassword(string login, string password);
    }
}
