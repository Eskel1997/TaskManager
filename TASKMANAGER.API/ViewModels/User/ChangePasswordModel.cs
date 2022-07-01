namespace TASKMANAGER.API.ViewModels.User
{
    public class ChangePasswordModel
    {
        public string OldPassword {get; set;}
        public string NewPassword {get ;set;}
        public string RepeatedPassword {get; set;}
    }
}
