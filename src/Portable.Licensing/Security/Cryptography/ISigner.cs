namespace Portable.Licensing.Security.Cryptography
{
    public interface ISigner
    {
        byte[] Sign(byte[] documentToSign, string privateKey, string passPhrase);
        bool VerifySignature(byte[] documentToSign, byte[] signature, string publicKey);
    }
}