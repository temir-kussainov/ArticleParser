using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUsersService
    {
        User GetUserByLoginPassword(string login, string password);
        User GetUserById(int userId);
    }
}
