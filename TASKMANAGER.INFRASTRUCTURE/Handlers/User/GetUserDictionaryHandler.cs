using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;
using TASKMANAGER.INFRASTRUCTURE.Queries.User;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.User
{
    public class GetUserDictionaryHandler : IRequestHandler<GetUserDictionaryQuery, List<GenericKeyValuePair>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDictionaryHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<GenericKeyValuePair>> Handle(GetUserDictionaryQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<List<GenericKeyValuePair>>(users);
        }
    }
}
