using System.Linq;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Project;
using TASKMANAGER.INFRASTRUCTURE.Queries.Project;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Project
{
    public class GetProjectDetailsHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsModel>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectDetailsHandler(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDetailsModel> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetQuery()
                .Include(p => p.Team)
                .Where(p => p.PublicId == request.PublicId)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);
            return _mapper.Map<ProjectDetailsModel>(project);
        }
    }
}
