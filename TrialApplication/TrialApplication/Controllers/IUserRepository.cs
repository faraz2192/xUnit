namespace TrialApplication.Controllers
{
    public interface IUserRepository
    {
        bool UserExists(string username);
        void RegisterNewUser(string username, string password);
        string GetPassword(string username);
        void DeregisterUser(string username);
    }
}
