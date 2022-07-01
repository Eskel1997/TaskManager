using System.Collections.Generic;
using TASKMANAGER.DB.Helpers;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Project
{
    public class ProjectListModel
    {
        public IList<ProjectListItemModel> Results { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
    }
}
