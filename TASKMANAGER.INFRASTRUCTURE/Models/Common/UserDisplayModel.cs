using System;

namespace TASKMANAGER.INFRASTRUCTURE.Models.Common
{
    public class UserDisplayModel
    {
        public Guid PublicId { get; set; }
        public string Username { get; set; }
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}
