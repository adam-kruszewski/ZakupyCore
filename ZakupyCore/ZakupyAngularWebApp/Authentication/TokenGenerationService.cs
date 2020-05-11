using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Kruchy.Uzytkownicy.Views;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;

namespace ZakupyAngularWebApp.Authentication
{
    public class TokenGenerationService : ITokenGenerationService
    {
        public static string KeysDirectory;

        private static string AesKeyPath => Path.Combine(KeysDirectory, "aes.key");

        private static string AesIVPath => Path.Combine(KeysDirectory, "aes.iv");

        public string GetToken(UzytkownikView uzytkownik)
        {
            var tokenData = new TokenData
            {
                Username = uzytkownik.Nazwa,
                Email = uzytkownik.Email,
                ExpirationDate = DateTime.Now.AddDays(1)
            };

            var writer = new StringWriter();
            new JsonSerializer().Serialize(writer, tokenData);
            var tokenDataString = writer.ToString();

            byte[] key, IV;
            var aesKeys = GetAesKeys();
            key = aesKeys.Item1;
            IV = aesKeys.Item2;

            // Encrypt the string to an array of bytes.
            byte[] encrypted = EncryptStringToBytes_Aes(tokenDataString, key, IV);

            string roundtrip = DecryptStringFromBytes_Aes(encrypted, key, IV);

            return Convert.ToBase64String(encrypted);
        }

        private Tuple<byte[], byte[]> GetAesKeys()
        {
            byte[] key;
            byte[] iv;

            if (!File.Exists(AesKeyPath) || !File.Exists(AesIVPath))
                GenerateNewKeys();

            key = Convert.FromBase64String(File.ReadAllText(AesKeyPath));
            iv = Convert.FromBase64String(File.ReadAllText(AesIVPath));

            return Tuple.Create(key, iv);
        }

        private void GenerateNewKeys()
        {
            using (Aes myAes = Aes.Create())
            {
                if (!File.Exists(AesKeyPath))
                    File.WriteAllText(AesKeyPath, Convert.ToBase64String(myAes.Key));

                if (!File.Exists(AesIVPath))
                    File.WriteAllText(AesIVPath, Convert.ToBase64String(myAes.IV));
            }
        }

        byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        private byte[] ReadKey(string path)
        {
            var lines = File.ReadAllLines(path);

            var linesWithKey = lines.Skip(1).Take(lines.Length - 2);

            var text = string.Join("", linesWithKey);

            var bytes = Base64UrlTextEncoder.Decode(text);

            return bytes;
        }

        private class TokenData
        {
            public string Username { get; set; }

            public string Email { get; set; }

            public DateTime ExpirationDate { get; set; }
        }
    }
}
