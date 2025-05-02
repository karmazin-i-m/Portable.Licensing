#if NET5_0
using System;
using System.Security.Cryptography;

namespace Portable.Licensing.Security.Cryptography
{
    internal class NativeSigner : ISigner
    {
        public byte[] Sign(byte[] documentToSign, string privateKey, string passPhrase)
        {
            var ecdsa = ECDsa.Create();
            ecdsa.ImportEncryptedPkcs8PrivateKey(passPhrase, Convert.FromBase64String(privateKey), out int _);
            return ecdsa.SignData(documentToSign, HashAlgorithmName.SHA512, DSASignatureFormat.Rfc3279DerSequence);
        }

        public bool VerifySignature(byte[] documentToSign, byte[] signature, string publicKey)
        {
            var ecdsa = ECDsa.Create();
            ecdsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out int read);
            return ecdsa.VerifyData(documentToSign, signature, HashAlgorithmName.SHA512, DSASignatureFormat.Rfc3279DerSequence);
        }
    }
}
#endif