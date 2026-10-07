using System.Security.Cryptography;
using System.Text;

namespace ItemsManager.Encryption
{
    internal class SymmetricEncryption
    {
        private readonly byte[] _salt = Encoding.Default.GetBytes("alamakota");
        private readonly Aes _algorithm = Aes.Create();

        public byte[] Encrypt(string stringToEncrypt, string password)
        {
            return Encrypt(Encoding.Default.GetBytes(stringToEncrypt), password);
        }
        public byte[] Encrypt(byte[] bytesToEncrypt, string password)
        {
            Rfc2898DeriveBytes passwordHash = GenerateHash(password);
            var key = GenerateKey(passwordHash);
            var iv = GenerateIV(passwordHash);

            ICryptoTransform encryptor = _algorithm.CreateEncryptor(key, iv);
            return Transform(bytesToEncrypt, encryptor);
        }

        public string Decrypt(byte[] bytesToDecrypt, string password)
        {
            Rfc2898DeriveBytes passwordHash = GenerateHash(password);
            var key = GenerateKey(passwordHash);
            var iv = GenerateIV(passwordHash);

            ICryptoTransform decryptor = _algorithm.CreateDecryptor(key, iv);
            var bytes = Transform(bytesToDecrypt, decryptor);

            return Encoding.Default.GetString(bytes);
        }

        private static byte[] Transform(byte[] bytes, ICryptoTransform cryptoTransform)
        {
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);

            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }

        private byte[] GenerateIV(Rfc2898DeriveBytes passwordHash)
        {
            return passwordHash.GetBytes(_algorithm.BlockSize / 8);
        }
        private byte[] GenerateKey(Rfc2898DeriveBytes passwordHash)
        {
            return passwordHash.GetBytes(_algorithm.KeySize / 8);
        }
        private Rfc2898DeriveBytes GenerateHash(string password)
        {
            return new Rfc2898DeriveBytes(password, _salt);
        }
    }
}
