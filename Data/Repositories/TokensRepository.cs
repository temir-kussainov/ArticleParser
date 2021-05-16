using Data.Repositories.Abstract;
using Domain;
using Entities;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TokensRepository: ITokensRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TokensRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateToken(TokenEntity token)
        {
            if (token is not null)
            {
                _databaseContext.Tokens.Add(token);
                _databaseContext.SaveChanges();
            }
        }

        public bool IsValidRefreshToken(int id, string refresh)
        {
            var exists = _databaseContext.Tokens
               .Where(x => x.UserId == id &&
               x.RefreshToken == refresh &&
               x.Used == false &&
               x.ExpiryDate > DateTime.Now &&
               x.CreatedDate < DateTime.Now).FirstOrDefault();

            if (exists is not null)
            {
                exists.Used = true;
                _databaseContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
