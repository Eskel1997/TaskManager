using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TASKMANAGER.INFRASTRUCTURE.Commands.Comment;
using TASKMANAGER.INFRASTRUCTURE.Models.Comment;
using TASKMANAGER.INFRASTRUCTURE.Queries.Comment;
using System.Collections.Generic;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/comment")]
    public class CommentController : AbstractController
    {
        public CommentController(IMediator mediator) : base(mediator) {}

        [HttpGet]
        public async Task<ActionResult<List<ListItemModel>>> Comments([FromQuery] GetTaskCommentsQuery model)
        {
            var result = await Handle(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCommentCommand model)
        {
            var result = await Handle(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCommentCommand model)
        {
            var result = await Handle(model);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteCommentCommand model)
        {
            var result = await Handle(model);
            return Ok();
        }
    }
}
