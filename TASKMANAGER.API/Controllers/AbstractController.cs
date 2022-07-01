using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TASKMANAGER.DB.Extensions;
using TASKMANAGER.INFRASTRUCTURE;

namespace TASKMANAGER.API.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        private readonly IMediator _mediator;
        protected AbstractController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<T> Handle<T>(IRequest<T> request)
        {
            if (request is IAuth)
            {
                var userId = User.GetUserId();
                (request as IAuth).UserId = userId;
            }

            return await _mediator.Send(request);
        }
    }
}
