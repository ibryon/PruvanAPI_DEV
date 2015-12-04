using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace PruvanAPI_13.Models
{
    public class LoginHelper
    {
        public LoginHelper()
        {
        }

        public static string GenerateSalt()
        {
            byte[] numArray = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(numArray);
            return Convert.ToBase64String(numArray);
        }

        public static string Hash(string salt, string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] numArray = Convert.FromBase64String(salt);
            byte[] numArray1 = new byte[(int)numArray.Length + (int)bytes.Length];
            Buffer.BlockCopy(numArray, 0, numArray1, 0, (int)numArray.Length);
            Buffer.BlockCopy(bytes, 0, numArray1, (int)numArray.Length, (int)bytes.Length);
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA1");
            return Convert.ToBase64String(hashAlgorithm.ComputeHash(numArray1));
        }
    }
}
