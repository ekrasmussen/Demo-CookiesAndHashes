using CookiesAndHashes_ClassLibrary;

namespace CookiesAndHashes_API.Database
{
    public class MockDatabase
    {
        public List<User> users;
        private static MockDatabase Instance = null;
        private MockDatabase()
        {
            users = new List<User>
            {
                new User()
                {
                    Username = "Mathias",
                    HashedPassword = "bd23e85f92a664e021518944d9e0fa36abd2d31d89b162f623c0aa56b5491133",
                    Salt = "0abc6c7d5de01cf6b36dd6c060129a7a",
                    Role = "User"
                },

                new User()
                {
                    Username = "Nicolai",
                    HashedPassword = "e70e4a0558ffaf0b31ab806f2a0d7243a4bc8f5d38de5d6e770e5eb52a1eb34c",
                    Salt = "b6545cc32641a2d19da11e8f0066cd7d",
                    Role = "User"
                },

                new User()
                {
                    Username = "Marin",
                    HashedPassword = "191f6558773d771fe252990ec966ae57d064343a0b9998fe8760ea7d49974b12",
                    Salt = "0f06d74981e01b0953fc34ce4963cbf9",
                    Role = "User"
                },

                new User()
                {
                    Username = "Andreas",
                    HashedPassword = "d9ab3f09a52af7e5d8c6dd081ada8a0419a20f2ba0b106f998256cdbc1d92d72",
                    Salt = "07690fde1e187067a2b9968448aa1493",
                    Role = "Admin"
                },

                new User()
                {
                    Username = "Martin",
                    HashedPassword = "e32914895baf9cca5fdd2652a4910778a776d708a59e4e6f53dbbb3925ef6c34",
                    Salt = "4054436bd694d78dbe31fb7f4fe415db",
                    Role = "Admin"
                },

                new User()
                {
                    Username = "Emil",
                    HashedPassword = "2542ef8e852b62b90b6c5ef7dbb86844d5ec0b6fefa098dbfee6e8af8da74889",
                    Salt = "3e36cb6c42e0a5bcc7ac8609ffd86e31",
                    Role = "Admin"
                }
            };
        }

        public static MockDatabase GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MockDatabase();
            }
            return Instance;
        }
    }
}
