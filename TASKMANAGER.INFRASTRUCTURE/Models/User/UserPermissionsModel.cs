namespace TASKMANAGER.INFRASTRUCTURE.Models.User
{
    public class UserPermissionsModel
    {
        public bool SuperAdmin {get;set;}
        public bool CanAddEditTask { get; set; }
        public bool CanAddEditProject { get; set; }
        public bool CanAddEditTeam { get; set; }
    }
}
