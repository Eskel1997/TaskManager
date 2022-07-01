using System;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Project
{
    public class ProjectDetailsModel
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public GenericKeyValuePair Status { get; set; }
        public GenericKeyValuePair Team { get; set; }
    }
}
