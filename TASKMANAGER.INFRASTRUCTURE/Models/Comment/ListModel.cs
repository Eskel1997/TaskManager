using System.Collections.Generic;
using TASKMANAGER.DB.Helpers;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Comment
{
    public class ListModel
    {
        public IList<ListItemModel> Results { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
    }
}
