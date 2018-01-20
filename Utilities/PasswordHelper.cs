using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utilities
{
    public class PasswordsHelper
    {
        private static string _salt =
            "+cEW1883vVfV0nDe3cJnpR1mUyu+7Np66FYzc+Z8qXP4TnWMWO8ZKZBrcp9Yw+G/sIA9Nq8KVkGshiLece3lunKVf/36D3+IXSMnmZgDRhFKHozD0yedeBS7QNQdb+G2qJ0dDAWximmhWUbwf5JrF3Gmr6TIgV126ryy+n0oHC6yby4FNzhY1UlqIiq28EZpQyS6fD3YkcMRokb4RQR/BallcrV0S/2zWGGGnGQnMgDwQCZVnUJe5yU8cPDf5h5FrL2plUzK1E3bOQ0XMMCJZpUWrTbevRs5qzRKs9haUzt1Z/7a3KxazVwNvY1R2doRrPwdFjkt5JiEGfsjCAhSrg==";

        public static string HashPassword(string rawPassword)
        {
            String hashedPassword = GenerateSha256Hash(rawPassword, _salt);
            return hashedPassword;
        }

        public static string CreateSalt(int Size)
        {
            var Rang = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var Buff = new byte[Size];
            Rang.GetBytes(Buff);
            return Convert.ToBase64String(Buff);
        }

        public static string GenerateSha256Hash(string Input, string Salt)
        {
            byte[] Bytes = System.Text.Encoding.UTF8.GetBytes(Input + Salt);
            System.Security.Cryptography.SHA256Managed Sha256Shashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] Hash = Sha256Shashstring.ComputeHash(Bytes);
            return Convert.ToBase64String(Hash);

        }

        public static string EncryptPassword(string rawPassword)
        {
            string PassPhrase = "$#$%(*)%$#$#@$ghj123456789";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return Crypto.Encrypt(serializer.Serialize(rawPassword), PassPhrase);
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            string PassPhrase = "$#$%(*)%$#$#@$ghj123456789";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var decrypted = Crypto.Decrypt(encryptedPassword, PassPhrase);
            return serializer.Deserialize(decrypted, typeof(string)).ToString();
        }

        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

    }
}
