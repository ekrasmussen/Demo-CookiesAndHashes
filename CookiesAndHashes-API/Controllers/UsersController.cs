using CookiesAndHashes_API.Database;
using CookiesAndHashes_ClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace CookiesAndHashes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public MockDatabase mockDatabase = MockDatabase.GetInstance();

        public UsersController()
        {

        }

        [HttpGet, Route("{username}")]
        public User Get(string username)
        {
            return mockDatabase.users.FirstOrDefault(x => x.Username == username);
        }
    }
}
