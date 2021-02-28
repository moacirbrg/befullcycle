using System.Security.Cryptography;
using System.Text;

namespace Lib.Utils
{
    public static class HashUtils
    {
        public static string Sha256(string str)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] hash = sha256.ComputeHash(bytes);
                var builder = new StringBuilder();

                foreach (byte t in hash)
                {
                    builder.Append(t.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}