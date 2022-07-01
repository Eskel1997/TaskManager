using System;
using System.Security.Cryptography;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Managers.Concrete
{
    public class EncryptionManager : IEncryptionManager
    {
        public EncryptionManager()
        {

        }
        public string GetSalt()
        {
            var saltBytes = new byte[40];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string password, string salt)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new TaskManagerException(ErrorCode.IncorrectAuthCredentials);
            }

            if(string.IsNullOrWhiteSpace(salt))
            {
                throw new TaskManagerException(ErrorCode.IncorrectAuthCredentials);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, GetBytes(salt), 10000);

            return Convert.ToBase64String(pbkdf2.GetBytes(40));
        }

        public void CompareHash(string hash, string hashGiven)
        {
            if (hashGiven != hash)
            {
                throw new TaskManagerException(ErrorCode.IncorrectAuthCredentials);
            }
        }
        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
