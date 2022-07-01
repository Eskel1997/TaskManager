using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TASKMANAGER.API.ViewModels.Team;
using TASKMANAGER.INFRASTRUCTURE.Commands.Team;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Models.Team;
using TASKMANAGER.INFRASTRUCTURE.Queries.Team;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/team")]
    public class TeamController : AbstractController
    {
        private readonly IMapper _mapper;

        public TeamController(
            IMediator mediator,
            IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<TeamListModel>> GetAll([FromQuery] GetAllTeamsModel model, [FromQuery] PaginatedList pagination)
        {
            var query = _mapper.Map<GetAllTeamsQuery>(model);
            query.PageNumber = pagination.PageNumber;
            query.PageSize = pagination.PageSize;
            var result = await Handle(query);
            return Ok(result);
        }
        [HttpGet("{publicId}")]
        public async Task<ActionResult<TeamDetailsModel>> GetDetails(Guid publicId)
        {
            var query = new GetTeamDetailsQuery(publicId);
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpGet("dictionary")]
        public async Task<ActionResult<List<GenericKeyValuePair>>> GetDictionary([FromQuery] GetTeamDictionaryModel model)
        {
            var query = _mapper.Map<GetTeamDictionaryQuery>(model);
            var result = await Handle(query);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTeamModel model)
        {
            var command = _mapper.Map<CreateTeamCommand>(model);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpPut("{publicId}/add-user/{userId}")]
        public async Task<ActionResult> AddUser(Guid publicId, Guid userId)
        {
            var command = new AddTeamUserCommand(publicId, userId);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpPut("{publicId}/remove-user/{userId}")]
        public async Task<ActionResult> RemoveUser(Guid publicId, Guid userId)
        {
            var command = new  RemoveTeamUserCommand(publicId, userId);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<ActionResult> Update([FromBody] UpdateTeamModel model)
        {
            var command = _mapper.Map<UpdateTeamCommand>(model);
            await Handle(command);
            return NoContent();
        }

        [HttpDelete("{publicId}")]
        public async Task<ActionResult> Delete(Guid publicId)
        {
            var command = new DeleteTeamCommand(publicId);
            await Handle(command);
            return Ok();
        }
    }
}
