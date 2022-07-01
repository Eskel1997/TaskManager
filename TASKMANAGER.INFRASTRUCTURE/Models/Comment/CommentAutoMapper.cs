using AutoMapper;
using TASKMANAGER.INFRASTRUCTURE.Resolvers;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Comment
{
    public class CommentAutoMapper : Profile
    {
        public CommentAutoMapper()
        {
            CreateMap<DB.Entities.Concrete.Comment, ListItemModel>()
                .ForMember(p => p.Comment, o => o.MapFrom(s => s.Text))
                .ForMember(p => p.AddedBy, o => o.MapFrom<UserResolver,long?>(s => s.CreatedById));
        }
    }
}
