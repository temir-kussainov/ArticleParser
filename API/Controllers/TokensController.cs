using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokensService _tokensService;
        private readonly IUsersService _usersService;
        public TokensController(IUsersService usersService, ITokensService tokensService)
        {
            _usersService = usersService;
            _tokensService = tokensService;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] AccountModel model)
        {
            User user = _usersService.GetUserByLoginPassword(model.Login, model.Password);

            if (user != null)
            {
                Token result = _tokensService.CreateToken(user);

                return Ok(result);
            }

            return BadRequest("User not found");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UpdateToken(TokenModel model)
        {
            ClaimsPrincipal claims = _tokensService.GetClaimsByExpiredAccess(model.Access);

            if (claims != null)
            {
                int userId = int.Parse(claims.FindFirst(ClaimTypes.NameIdentifier).Value);

                User user = _usersService.GetUserById(userId);

                bool isValidRefreshToken = _tokensService.IsValidRefreshToken(userId, model.Refresh);

                if (isValidRefreshToken)
                {
                    Token result = _tokensService.CreateToken(user);

                    return Ok(result);
                }
            }

            return BadRequest("User Token Expired");
        }
    }
}
