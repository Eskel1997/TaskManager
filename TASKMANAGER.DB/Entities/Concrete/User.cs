using System;
using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Entities.Concrete
{
    public class User : Entity
    {
        public Guid PublicId { get; protected set; }
        public string Name { get; protected set; }
        public string PictureUrl { get; protected set; }
        public string LastName { get; protected set; }
        public string Username { get; protected set; }
        public string Email {get ; protected set; }
        public string PasswordSalt { get; protected set; }
        public string PasswordHash { get; protected set; }
        public string RefreshToken { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime LastActiveAt { get; protected set; }
        public DateTime RegisteredAt { get; protected set; }

        public User() {}

        public User(string name, string pictureUrl,
            string lastName, string username, string email,
            string passwordHash, string passwordSalt)
        {
            SetPublicId();
            ChangeIsActive(true);
            ChangeLastActive();
            SetRegisterDate();
            ChangeName(name);
            ChangePicture(pictureUrl);
            ChangeLastName(lastName);
            ChangeUsername(username);
            ChangeEmail(email);
            ChangePassword(passwordHash, passwordSalt);
        }

        public void ChangeRefreshToken(string token)
        {
            RefreshToken = token;
        }
        public void ChangeIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void ChangePassword(string hash, string salt)
        {
            PasswordHash = hash;
            PasswordSalt = salt;
        }
        public void ChangeLastActive()
        {
            LastActiveAt = DateTime.Now;
        }
        public void ChangePicture(string pictureUrl)
        {
            PictureUrl = pictureUrl;
        }

        private void SetPublicId()
        {
            PublicId = Guid.NewGuid();
        }

        private void ChangeName(string name)
        {
            Name = name;
        }


        private void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }

        private void ChangeUsername(string username)
        {
            Username = username;
        }

        private void ChangeEmail(string email)
        {
            Email = email;
        }


        private void SetRegisterDate()
        {
            RegisteredAt = DateTime.Now;
        }

    }
}
