using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.Shared
{
    public class Sha256Helper
    {
        public static string WriteSha256AsString(string Value)
        {
            var message = Encoding.UTF8.GetBytes(Value);
            SHA256 hashString = SHA256.Create();

            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += string.Format("{0:x2}", x);
            }

            return hex;
        }

    }
}
