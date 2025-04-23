using System.Security.Cryptography;
using System.Text;

namespace BarbeariaWeb.Areas.SignIn.Models
{
    public class CriptoUtils
    {
        // As chaves devem ter exatamente 16 caracteres para AES-128
        private static readonly string FixedKey = "MinhaChave123456";
        private static readonly string FixedIV = "MeuVetorInit1234";

        public static string Criptografar(string plainText)
        {
            byte[] key = Encoding.UTF8.GetBytes(FixedKey);
            byte[] iv = Encoding.UTF8.GetBytes(FixedIV);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor();

                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                    encryptedBytes = ms.ToArray();
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Descriptografar(string encryptedText)
        {
            byte[] key = Encoding.UTF8.GetBytes(FixedKey);
            byte[] iv = Encoding.UTF8.GetBytes(FixedIV);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor();

                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
