using System;

namespace TASKMANAGER.API.Validators.Comment
{
    public class GetAllTaskCommentsModel
    {
        public Guid TaskId { get; set; }
        public string Search { get; set; }
    }
}
