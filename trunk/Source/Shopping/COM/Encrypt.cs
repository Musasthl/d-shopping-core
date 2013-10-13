using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace COM
{
    public class Encrypt
    {
        public static string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        public static string VerifyPhone(string originalPhone)
        {
            if (originalPhone == null || originalPhone.Length < 5)
            {
                return "";
            }
            else
                return "***-***-" + originalPhone.Substring(originalPhone.Length - 4, originalPhone.Length);
        }
    }
}
