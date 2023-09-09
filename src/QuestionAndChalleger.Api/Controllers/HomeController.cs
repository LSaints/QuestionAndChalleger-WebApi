using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Manager;
using QuestionAndChalleger.Manager.Interfaces.Services;
using System.Security.Claims;

namespace QuestionAndChalleger.Api.Controllers
{
    [Route("api/account")]
    public class HomeController : ControllerBase
    {
        private readonly IUserManager _manager;
        private readonly ITokenServices _tokenService;

        public HomeController(IUserManager manager, ITokenServices tokenService)
        {
            _manager = manager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User entity)
        {
            User user = await _manager.GetByLogin(entity.Name, entity.Password);
            if (user == null)
            {
                return NotFound(new
                {
                    message = "User or Password is not valid"
                });
            }
            var token = _tokenService.GenerateToken(entity);
            return new {
                entity = entity,
                token = token,
            };
        }
        [HttpGet]
        [Route("auth")]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetUserInLogin()
        {
            return User.FindFirstValue(ClaimTypes.Role);
        }
    }
}
