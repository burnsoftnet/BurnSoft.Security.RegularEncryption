using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BurnSoft.Security.RegularEncryption.SHA
{
     public class One
    {
        /// <summary>
        /// Pass string to Encrypt using SHA
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string Encrypt(string Data)
        {
            SHA1Managed shaM = new SHA1Managed();
            Convert.ToBase64String(shaM.ComputeHash(Encoding.ASCII.GetBytes(Data)));
            byte[] eNC_data = ASCIIEncoding.ASCII.GetBytes(Data);
            string eNC_str = Convert.ToBase64String(eNC_data);
            return eNC_str;
        }

    }
}
