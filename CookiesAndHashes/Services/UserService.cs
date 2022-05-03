using CookiesAndHashes_ClassLibrary;

namespace CookiesAndHashes.Services
{
    internal class UserService : Connection
    {
        public UserService() : base()
        {

        }

        public async Task<User> GetByUsername(string username)
        {
            User foundUser = await GetFromAPI<User>($"users/{username}");
            return foundUser;
        }
    }
}
