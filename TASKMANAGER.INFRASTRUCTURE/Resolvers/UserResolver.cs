using AutoMapper;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Resolvers
{
    public class UserResolver : IMemberValueResolver<object, object, long?, UserDisplayModel>
    {
        private readonly IUserRepository _userRepository;

        public UserResolver(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDisplayModel Resolve(object source, object destination, long? sourceMember, UserDisplayModel destMember,
            ResolutionContext context)
        {
            if (sourceMember == null || sourceMember == 0)
                return new UserDisplayModel();

            var user = _userRepository.GetById(sourceMember.Value);

            return new UserDisplayModel()
            {
                PictureUrl = user.PictureUrl,
                Username = user.Username,
                Name = user.Name,
                LastName = user.LastName,
                PublicId = user.PublicId
            };
        }
    }
}
