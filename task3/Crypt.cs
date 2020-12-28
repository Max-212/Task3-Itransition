using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace task3
{
    public static class Crypt
    {
        public static string GenerateKey()
        {
            var rnd = RandomNumberGenerator.Create();
            var key = new byte[128/8];
            rnd.GetBytes(key);

            return BitConverter.ToString(key).Replace("-", string.Empty);
        }

        public static string GenerateHMAC(string key, string str)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                var bhash = hmac.ComputeHash(bstr);
                return BitConverter.ToString(bhash).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
