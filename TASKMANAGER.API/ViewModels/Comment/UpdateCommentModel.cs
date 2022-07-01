using System;

namespace TASKMANAGER.API.Validators.Comment
{
    public class UpdateCommentModel
    {
        public Guid PublicId { get; set; }
        public string Comment { get; set; }
    }
}
