using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TASKMANAGER.API.ViewModels.Task;
using TASKMANAGER.INFRASTRUCTURE.Commands.Task;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Models.Task;
using TASKMANAGER.INFRASTRUCTURE.Queries.Task;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/task")]
    public class TaskController : AbstractController
    {
        private readonly IMapper _mapper;
        public TaskController(
            IMediator mediator,
            IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet("my")]
        public async Task<ActionResult<List<TaskListItemModel>>> GetMy()
        {
            var query = new GetMyLastTaskQuery();
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<ActionResult<TaskListModel>> GetList([FromQuery] GetAllTaskModel model, [FromQuery] PaginatedList pagination)
        {
            var query = _mapper.Map<GetAllTaskQuery>(model);
            query.PageNumber = pagination.PageNumber;
            query.PageSize = pagination.PageSize;
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpGet("{publicId}")]
        public async Task<ActionResult<TaskDetailsModel>> GetDetails(Guid publicId)
        {
            var query = new GetTaskDetailsQuery(publicId);
            var result = await Handle(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTaskModel model)
        {
            var command = _mapper.Map<CreateTaskCommand>(model);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTaskModel model)
        {
            var command = _mapper.Map<UpdateTaskCommand>(model);
            var result = await Handle(command);
            return Ok(result);
        }

        [HttpDelete("{publicId}")]
        public async Task<ActionResult> Delete(Guid publicId)
        {
            var command = new DeleteTaskCommand(publicId);
            var result = await Handle(command);
            return Ok(result);
        }
    }
}
