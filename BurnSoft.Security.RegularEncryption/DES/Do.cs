using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace BurnSoft.Security.RegularEncryption.DES
{
    public class Do
    {
        public static string Encrypt(string value, string key, string iVector)
        {
            string sAns = @"";
            System.Security.Cryptography.DES DESalg = System.Security.Cryptography.DES.Create();
            FileStream fStream = File.Open($"{AppDomain.CurrentDomain.BaseDirectory}\\test.log", FileMode.OpenOrCreate);
            // Create a CryptoStream using the FileStream
            // and the passed key and initialization vector (IV).
            CryptoStream cStream = new CryptoStream(fStream,
                DESalg.CreateEncryptor(ASCIIEncoding.ASCII.GetBytes(key), ASCIIEncoding.ASCII.GetBytes(iVector)),
                CryptoStreamMode.Write);
            MemoryStream ms = new MemoryStream();
            ms.Position = 0;
            // Create a StreamWriter using the CryptoStream.
            StreamWriter sWriter = new StreamWriter(cStream);
            // Write the data to the stream
            // to encrypt it.
            sWriter.WriteLine(value);
            sWriter.Write(ms);
            StreamReader sr = new StreamReader(ms);
            sAns = sr.ReadToEnd();
            //cStream.CopyTo(ms);
            // Close the streams and
            // close the file.
            sWriter.Close();
            cStream.Close();
            fStream.Close();
            return sAns;
        }
    }
}
