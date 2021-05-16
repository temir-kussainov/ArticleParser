using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ITokensService
    {
        Token CreateToken(User user);
        ClaimsPrincipal GetClaimsByExpiredAccess(string access);
        bool IsValidRefreshToken(int id, string refresh);
    }
}
