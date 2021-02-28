using System;
using System.Linq;

namespace Lib.Utils
{
    public static class PasswordUtils
    {
        public static string CreateWeakPassword()
        {
            const int length = 8;
            const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ123456789abcdefghjkmnpqrstuvwxyz";
            
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}