using System;
using System.Text;
using System.Security.Cryptography;

namespace BurnSoft.Security.RegularEncryption.SHA
{
    /// <summary>
    /// Perform a SHA1 Encryption. decryption 
    /// </summary>
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

        /// <summary>
        /// Encypt the details of a url using SHA
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strSessionID"></param>
        /// <returns></returns>
        public static string EncryptURL(string strUrl, string strSessionID)
        {
            string strReturn = $"{strSessionID}|{strUrl.Trim()}|{DateTime.Now.Ticks}";
            return Encrypt(strReturn.Trim());
        }

        /// <summary>
        /// Pass string to decrypt Using SHA
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string Decrypt(string Data)
        {
            try
            {
                byte[] dEC_data = Convert.FromBase64String(Data.Trim());
                string dEC_Str = ASCIIEncoding.ASCII.GetString(dEC_data);
                return dEC_Str;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Decrypt a URL using SHA
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static string DecryptURL(string strUrl)
        {
            string pageEncrypt;
            pageEncrypt = Decrypt(strUrl);
            string[] stringary = pageEncrypt.Split('|');
            return stringary[1];
        }

    }
}
