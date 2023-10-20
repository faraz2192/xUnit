namespace TrialApplication.Controllers
{
    public interface IUserRepository
    {
        bool UserExists(string username);
        void RegisterNewUser(string username, string password); 
    }
}
