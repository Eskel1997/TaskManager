using System;

namespace TASKMANAGER.API.ViewModels.Task
{
    public class GetAllTaskModel
    {
        public string Search { get; set; }
        public Guid? Project { get; set; }
        public Guid? User { get; set; }
    }
}
