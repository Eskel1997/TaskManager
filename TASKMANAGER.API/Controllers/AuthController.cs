using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using TASKMANAGER.INFRASTRUCTURE.Commands.Auth;
using TASKMANAGER.INFRASTRUCTURE.Models;
using Microsoft.Extensions.Logging;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Route("api/auth/")]
    public class AuthController : AbstractController
    {
        public AuthController(
            IMediator mediator) 
            : base(mediator) { }

        [HttpPost("log-in")]
        public async Task<ActionResult<TokenModel>> Login([FromBody] LoginUserCommand model)
        {
            var result = await Handle(model);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<TokenModel>> Refresh([FromBody] RefreshTokenCommand model)
        {
            var result = await Handle(model);
            return Ok(result);
        }

    }
}
