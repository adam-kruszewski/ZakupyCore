using System;
using System.IO;
using System.Security.Cryptography;
using Kruchy.Core.Cryptography;

namespace ZakupyAngularWebApp.Authentication
{
    class AesKeysProvider : IAesKeyProvider
    {
        public static string KeysDirectory;

        private static string AesKeyPath => Path.Combine(KeysDirectory, "aes.key");

        private static string AesIVPath => Path.Combine(KeysDirectory, "aes.iv");

        public byte[] GetIV()
        {
            GenerateNewKeysIfNotExist();

            return Convert.FromBase64String(File.ReadAllText(AesIVPath));
        }

        public byte[] GetKey()
        {
            GenerateNewKeysIfNotExist();

            return Convert.FromBase64String(File.ReadAllText(AesKeyPath));
        }

        private void GenerateNewKeysIfNotExist()
        {
            if (File.Exists(AesKeyPath) && File.Exists(AesIVPath))
                return;

                using (Aes myAes = Aes.Create())
            {
                if (!File.Exists(AesKeyPath))
                    File.WriteAllText(AesKeyPath, Convert.ToBase64String(myAes.Key));

                if (!File.Exists(AesIVPath))
                    File.WriteAllText(AesIVPath, Convert.ToBase64String(myAes.IV));
            }
        }
    }
}