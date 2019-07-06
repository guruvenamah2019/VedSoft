using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VedSoft.Utility
{
    public static class DataHashing
    {
        public const string encrptionVector = "7061737323313233";

        public static string GetSHA1HashData(string data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(data))
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// Get 16 digit encryption key
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public static string GetEncryptKey(string sessionId)
        {
            string key = string.Empty;
            byte[] rijnKey = Encoding.ASCII.GetBytes(sessionId);

            ////16 * 8 = 128 bits
            if (rijnKey.Length < 16)
            {
                int length = 16 - rijnKey.Length;
                Random randomGenerator = new Random();
                byte[] randomBytes = new byte[randomGenerator.Next(length)];
                randomGenerator.NextBytes(randomBytes);
                string randomString = Convert.ToBase64String(randomBytes);
                key = string.Format("{0}{1}", sessionId, randomString);
            }
            else if (rijnKey.Length > 16)
            {
                key = sessionId.Substring(0, 16);
            }
            else
            {
                key = sessionId;
            }
            return key;
        }

        public static String EncryptIt(String s, byte[] key, byte[] IV)
        {
            String result;

            RijndaelManaged rijn = new RijndaelManaged();
            rijn.KeySize = 128;
            rijn.Mode = CipherMode.CBC;
            rijn.Padding = PaddingMode.PKCS7;

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (ICryptoTransform encryptor = rijn.CreateEncryptor(key, IV))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(s);
                        }
                    }
                }
                result = Convert.ToBase64String(msEncrypt.ToArray());
            }
            rijn.Clear();

            return result;
        }

        public static String DecryptIt(String s, byte[] key, byte[] IV)
        {
            String result;

            RijndaelManaged rijn = new RijndaelManaged();
            rijn.KeySize = 128;
            rijn.Mode = CipherMode.CBC;
            rijn.Padding = PaddingMode.PKCS7;

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(s)))
            {
                using (ICryptoTransform decryptor = rijn.CreateDecryptor(key, IV))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                        {
                            result = swDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            rijn.Clear();

            return result;
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
}
