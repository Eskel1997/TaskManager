using System;

namespace TASKMANAGER.API.ViewModels.User
{
    public class UserFilterModel
    {
        public Guid? TeamId { get; set; }
        public string Name { get; set; }
    }
}
