namespace TrialApplication.Controllers
{
    public class UserManager
    {
        private IUserRepository userRepository;
        public UserManager (IUserRepository repository)
        {
            userRepository = repository;
        }

        public bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false; // Incomplete user data
            }
            if (userRepository.UserExists(username))
            {
                return false; // User already exists
            }

            userRepository.RegisterNewUser(username, password);
            return true;
        }
    }
}
