using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Queries.Project;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.Project
{
    public class GetProjectDictionaryHandler : IRequestHandler<GetProjectDictionaryQuery, List<GenericKeyValuePair>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetProjectDictionaryHandler(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<List<GenericKeyValuePair>> Handle(GetProjectDictionaryQuery request, CancellationToken cancellationToken)
        {
            var list = _projectRepository.GetQuery();

            if (!string.IsNullOrEmpty(request.Search))
                list = list.Where(p => p.Name.ToLower().Contains(request.Search.ToLower()));

            return _mapper.Map<List<GenericKeyValuePair>>(await list.ToListAsync(cancellationToken: cancellationToken));
        }
    }
}
