using System;

namespace TASKMANAGER.INFRASTRUCTURE.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name {get; set;}
        public string Surname {get;set;}
        public string PictureUrl {get; set;}
    }
}
