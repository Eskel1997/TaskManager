using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Commands.File;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/files")]
    public class FileController : AbstractController
    {
        public FileController(IMediator mediator) : base(mediator) { }

        [HttpPost("upload")]
        public async Task<ActionResult<string>> UploadFile([FromForm] IFormFile file)
        {
            if(file == null)
                return BadRequest("File is Empty");
            var result = await Handle(new FileUploadCommand(file));
            return Ok(result);
        }
    }

}
