using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TASKMANAGER.DB.Enums;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/dictionary")]
    public class DictionaryController : AbstractController
    {
        public DictionaryController(IMediator mediator) : base(mediator) {   }

        [HttpGet("project-statuses")]
        public ActionResult<List<GenericKeyValuePair>> GetAllProjectStates()
        {
            return Enum.GetValues(typeof(ProjectStatusEnum))
                .Cast<ProjectStatusEnum>()
                .Select(p => new GenericKeyValuePair(((int)p).ToString(),p.ToString()))
                .ToList();
        }

        [HttpGet("task-statuses")]
        public ActionResult<List<GenericKeyValuePair>> GetAllTaskStates()
        {
            return Enum.GetValues(typeof(TaskStatusEnum))
                .Cast<ProjectStatusEnum>()
                .Select(p => new GenericKeyValuePair(((int)p).ToString(),p.ToString()))
                .ToList();
        }

        [HttpGet("task-priority")]
        public ActionResult<List<GenericKeyValuePair>> GetAllTaskPriority()
        {
            return Enum.GetValues(typeof(TaskPriorityEnum))
                .Cast<ProjectStatusEnum>()
                .Select(p => new GenericKeyValuePair(((int)p).ToString(),p.ToString()))
                .ToList();
        }
    }
}
