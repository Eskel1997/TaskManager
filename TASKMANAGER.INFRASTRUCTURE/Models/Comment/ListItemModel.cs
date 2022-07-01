using System;
using TASKMANAGER.INFRASTRUCTURE.Models.Common;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Comment
{
    public class ListItemModel
    {
        public Guid PublicId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt {get; set;}
        public UserDisplayModel AddedBy { get; set; }

    }
}
