using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ItemsManager.Encryption
{
    internal class AsymmetricEncryption
    {
        public byte[] Encrypt(string stringToEncrypt, string certName)
        {
            return Encrypt(Encoding.Default.GetBytes(stringToEncrypt), certName);
        }

        public byte[] Encrypt(byte[] bytesToEncrypt, string certName)
        {
            X509Certificate2? cert = GetCert(certName);

            RSA? provider = cert.PublicKey.GetRSAPublicKey();

            using var algorithm = Aes.Create();

            using var outStream = new MemoryStream();
            using ICryptoTransform encryptor = algorithm.CreateEncryptor();

            var keyFormatter = new RSAPKCS1KeyExchangeFormatter(provider);
            var encyptedKey = keyFormatter.CreateKeyExchange(algorithm.Key, algorithm.GetType());

            var keyLength = BitConverter.GetBytes(encyptedKey.Length);
            var ivLength = BitConverter.GetBytes(algorithm.IV.Length);


            outStream.Write(keyLength, 0, 4);
            outStream.Write(ivLength, 0, 4);
            outStream.Write(encyptedKey, 0, encyptedKey.Length);
            outStream.Write(algorithm.IV, 0, algorithm.IV.Length);

            using var encrypt = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write);

            encrypt.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
            encrypt.FlushFinalBlock();

            return outStream.ToArray();
        }

        public byte[] Decrypt(byte[] bytesToDecrypt, string certName)
        {
            X509Certificate2? cert = GetCert(certName);
            RSA? provider = cert.GetRSAPrivateKey();

            using var algorithm = Aes.Create();
            using var inStream = new MemoryStream(bytesToDecrypt);

            var keyLength = new byte[4];
            var ivLength = new byte[4];
            _ = inStream.Seek(0, SeekOrigin.Begin);

            _ = inStream.Read(keyLength, 0, keyLength.Length);
            _ = inStream.Read(ivLength, 0, ivLength.Length);

            var keyLengthInt = BitConverter.ToInt32(keyLength, 0);
            var ivLengthInt = BitConverter.ToInt32(ivLength, 0);

            var dataStartPosition = keyLengthInt + ivLengthInt + keyLength.Length + ivLength.Length;
            var dataSize = (int)inStream.Length - dataStartPosition;


            var key = new byte[keyLengthInt];
            var iv = new byte[ivLengthInt];
            var data = new byte[dataSize];

            _ = inStream.Read(key, 0, keyLengthInt);
            _ = inStream.Read(iv, 0, ivLengthInt);
            _ = inStream.Read(data, 0, dataSize);

            var decryptedKey = provider.Decrypt(key, RSAEncryptionPadding.Pkcs1);

            using var outStream = new MemoryStream();
            using ICryptoTransform decryptor = algorithm.CreateDecryptor(decryptedKey, iv);
            using var decrypStream = new CryptoStream(outStream, decryptor, CryptoStreamMode.Write);
            decrypStream.Write(data, 0, data.Length);
            decrypStream.FlushFinalBlock();

            var bytes = outStream.ToArray();
            return bytes;

        }

        private X509Certificate2? GetCert(string certName)
        {
            using X509Store store = new(StoreName.My, StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadOnly);

            return store.Certificates.SingleOrDefault(x => x.SubjectName.Name == certName);
        }
    }
}
