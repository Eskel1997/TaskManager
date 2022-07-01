using System.Collections.Generic;
using TASKMANAGER.DB.Helpers;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Task
{
    public class TaskListModel
    {
        public IList<TaskListItemModel> Results { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
    }
}
