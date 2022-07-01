namespace TASKMANAGER.DB.Enums
{
    public enum Permissions
    {
        SuperAdmin,
        CanAddEditTask,
        CanAddEditProject,
        CanAddEditTeam,
        CanAddEditComment
    }
    public static class UserPermissions
    {
        public static string GetText(Permissions permission)
        {
            switch (permission)
            {
                case Permissions.SuperAdmin: return "SuperAdmin";
                case Permissions.CanAddEditTeam: return "Can add and edit Team";
                case Permissions.CanAddEditTask: return "Can add and edit Task";
                case Permissions.CanAddEditProject: return "Can add and edit Project";
                case Permissions.CanAddEditComment: return "Can add comments";
                default: return string.Empty;
            }
        }
    }
}
