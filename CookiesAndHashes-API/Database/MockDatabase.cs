using CookiesAndHashes_ClassLibrary;

namespace CookiesAndHashes_API.Database
{
    public class MockDatabase
    {
        public List<User> users;

        private MockDatabase()
        {
            users = new List<User>
            {
                new User()
                {
                    Username = "Breiner",
                    HashedPassword = 
                }
            };
        }
    }
}
