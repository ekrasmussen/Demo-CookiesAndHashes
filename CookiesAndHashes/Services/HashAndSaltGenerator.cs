using System.Security.Cryptography;
using System.Text;

namespace CookiesAndHashes.Services
{
    public static class HashAndSaltGenerator
    {

        /// <summary>
        /// Convert a string of text to its hash value
        /// </summary>
        /// <param name="text">text to be hashed</param>
        /// <returns>a hashed version of the text</returns>
        public static string GetHash(string text, string salt)
        {
            //In this demo i am going to append the salt at the end of the input
            string textAndSalt = text + salt;

            using(var sha256 = SHA256.Create())
            {
                //convert this to hashed bytes first..
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(textAndSalt));

                //.. And then we convert it back to readable text
                //the replace and tolower is just for getting it a bit uniform
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string GenerateSalt()
        {
            //First we create an array for bytes
            //THIS IS NOT THE ONLY WAY TO DO IT. Its just to get a completely random sequence of text
            byte[] bytes = new byte[128 / 8];
            using(var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
