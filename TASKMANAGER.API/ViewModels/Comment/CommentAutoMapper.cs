using AutoMapper;
using TASKMANAGER.API.Validators.Comment;
using TASKMANAGER.INFRASTRUCTURE.Commands.Comment;
using TASKMANAGER.INFRASTRUCTURE.Queries.Task;

namespace TASKMANAGER.API.ViewModels.Comment
{
    public class CommentAutoMapper : Profile
    {
        public CommentAutoMapper()
        {
            CreateMap<CreateCommentModel, CreateCommentCommand>();
            CreateMap<UpdateCommentModel, UpdateCommentCommand>();
            CreateMap<GetAllTaskCommentsModel, GetAllTaskQuery>();
        }
    }
}
