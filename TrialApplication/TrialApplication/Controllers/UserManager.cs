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
            if (userRepository.UserExists(password))
            {
                return false;
            }

            userRepository.RegisterNewUser(username, password);
            return true;
        }

        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (!userRepository.UserExists(username))
            {
                return false;
            }
            // Retrieve the stored password for the user
            string storedPassword = userRepository.GetPassword(username);
            if (storedPassword == password)
            {
                return true;
            }
            return false;
        }

        public bool DeRegister(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false; // Incomplete user data
            }

            if (!userRepository.UserExists(username))
            {
                return false; // User does not exist
            }

            // Retrieve the stored password for the user
            string storedPassword = userRepository.GetPassword(username);

            if (storedPassword == password)
            {
                // Passwords match, proceed to deregister the user
                userRepository.DeregisterUser(username);
                return true; // Successful deregistration
            }

            return false;
        }

        public bool Logout(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;
            if (!userRepository.UserExists(username))
                return false;


            return true;
        }
    }
}
