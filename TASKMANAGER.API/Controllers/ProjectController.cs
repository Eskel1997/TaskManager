using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TASKMANAGER.API.ViewModels.Project;
using TASKMANAGER.INFRASTRUCTURE.Commands.Project;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Models.Project;
using TASKMANAGER.INFRASTRUCTURE.Queries.Project;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/project")]
    public class ProjectController : AbstractController
    {
        private readonly IMapper _mapper;

        public ProjectController(
            IMediator mediator,
            IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ProjectListModel>> GetList([FromQuery] GetAllProjectsModel model, [FromQuery] PaginatedList pagination)
        {
            var query = _mapper.Map<GetAllProjectsQuery>(model);
            query.PageNumber = pagination.PageNumber;
            query.PageSize = pagination.PageSize;
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpGet("dictionary")]
        public async Task<ActionResult<List<GenericKeyValuePair>>> GetDictionary([FromQuery] GetProjectDictionaryModel model)
        {
            var query = _mapper.Map<GetProjectDictionaryQuery>(model);
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpGet("{publicId}")]
        public async Task<ActionResult<ProjectDetailsModel>> GetDetails(Guid publicId)
        {
            var query = new GetProjectDetailsQuery(publicId);
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProjectModel model)
        {
            var command = _mapper.Map<CreateProjectCommand>(model);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateProjectModel model)
        {
            var command = _mapper.Map<UpdateProjectCommand>(model);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpDelete("{publicId}")]
        public async Task<ActionResult> Delete(Guid publicId)
        {
            var command = new DeleteProjectCommand(publicId);
            var result = await Handle(command);
            return Ok(result);
        }
    }
}
