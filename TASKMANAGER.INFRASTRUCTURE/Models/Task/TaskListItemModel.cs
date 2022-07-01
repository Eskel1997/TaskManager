using System;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Models
{
    public class TaskListItemModel
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public GenericKeyValuePair Priority { get; set; }
        public GenericKeyValuePair Status { get; set; }
        public GenericKeyValuePair Project { get; set; }
        public UserDisplayModel CreatedBy { get; set; }
        public UserDisplayModel Owner {get ; set; }
    }
}
