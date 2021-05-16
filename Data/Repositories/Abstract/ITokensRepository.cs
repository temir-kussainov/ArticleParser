using Domain;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface ITokensRepository
    {
        void CreateToken(TokenEntity token);
        bool IsValidRefreshToken(int id, string refresh);
    }
}
