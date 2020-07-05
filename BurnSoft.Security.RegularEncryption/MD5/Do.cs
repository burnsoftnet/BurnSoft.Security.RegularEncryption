using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BurnSoft.Security.RegularEncryption.MD5
{
    public class Do
    {
        /// <summary>
        /// Pass a string to Encrypt using MD5
        /// </summary>
        /// <param name="cleanString"></param>
        /// <returns></returns>
        public static string Encrypt(string cleanString)
        {

            // Convert the input string to a byte array and compute the hash.
            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(cleanString));
            // Create a new Stringbuilder to collect the bytes
            // // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // // and format each one as a hexadecimal string
            // .
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
