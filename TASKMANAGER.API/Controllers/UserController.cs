using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TASKMANAGER.API.ViewModels.User;
using TASKMANAGER.INFRASTRUCTURE.Commands.User;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Models.User;
using TASKMANAGER.INFRASTRUCTURE.Queries.User;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : AbstractController
    {
        private readonly IMapper _mapper;

        public UserController(
            IMediator mediator,
            IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet("dictionary")]
        [Authorize]
        public async Task<ActionResult<List<GenericKeyValuePair>>> GetDictionaryTask()
        {
            var query = new GetUserDictionaryQuery();
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpGet("list")]
        [Authorize]
        public async Task<ActionResult<List<UserDisplayModel>>> GetList([FromQuery] UserFilterModel model)
        {
            var query = _mapper.Map<GetUsersQuery>(model);
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpPost("register")]
        
        public async Task<ActionResult<TokenModel>> Register([FromBody] RegisterCommand model)
        {
            var result = await Handle(model);
            return Ok(result);
        }

        [HttpPut("change-password")]
        [Authorize]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var command = _mapper.Map<ChangePasswordCommand>(model);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpPut("picture")]
        [Authorize]
        public async Task<ActionResult> EditUser([FromBody] EditPictureModel model)
        {
            var command = _mapper.Map<EditPictureCommand>(model);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpPut("my-permissions")]
        [Authorize]
        public async Task<ActionResult> UpdateMyPermissions([FromBody] UserPermissionsModel model)
        {
            var command = new UpdateMyPermissionsCommand(model);
            var result = await Handle(command);

            return Ok(result);
        }

        [HttpPut("permissions/{publicId}")]
        [Authorize]
        public async Task<ActionResult<UserPermissionsModel>> UpdateUserPermissions(string publicId, [FromBody] UserPermissionsModel model)
        {
            var command = new UpdateUserPermissionsCommand(publicId, model);
            var result = await Handle(command);

            return Ok(result);
        }

        [HttpGet("my-permissions")]
        [Authorize]
        public async Task<ActionResult<UserPermissionsModel>> MyPermissions()
        {
            var query = new GetMyPermissionsQuery();
            var result = await Handle(query);

            return Ok(result);
        }

        [HttpGet("permissions/{publicId}")]
        [Authorize]
        public async Task<ActionResult<UserPermissionsModel>> Permissions(string publicId)
        {
            var query = new GetUserPermissionsQuery(publicId);
            var result = await Handle(query);

            return Ok(result);
        }
    }
}
