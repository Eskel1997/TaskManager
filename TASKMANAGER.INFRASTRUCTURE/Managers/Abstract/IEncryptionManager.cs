namespace TASKMANAGER.INFRASTRUCTURE.Managers.Abstract
{
    public interface IEncryptionManager
    {
        string GetSalt();
        string GetHash(string password, string salt);
        void CompareHash(string hash, string hashGiven);
    }
}
