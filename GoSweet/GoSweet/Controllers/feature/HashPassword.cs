using System.Security.Cryptography;
using System.Text;

namespace GoSweet.Controllers.feature
{
    public class HashPassword
    {
        //private string salt = "abc";
        public string CreateSha256Password(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            // create salt password
            string saltPassword = password;

            // Compute hash
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltPassword));

            StringBuilder builder = new StringBuilder();

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
