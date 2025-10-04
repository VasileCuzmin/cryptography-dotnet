using System.Security.Cryptography;

namespace AES;

public static class AesGcmEncryption
{
    public static (byte[], byte[]) Encrypt(byte[] dataToEncrypt, byte[] key, byte[] nonce, byte[] associatedData)
    {
        // these will be filled during the encryption
        var tag = new byte[16];
        var ciphertext = new byte[dataToEncrypt.Length];

        using var aesGcm = new AesGcm(key);
        aesGcm.Encrypt(nonce, dataToEncrypt, ciphertext, tag, associatedData);

        return (ciphertext, tag);
    }

    public static byte[] Decrypt(byte[] cipherText, byte[] key, byte[] nonce, byte[] tag, byte[] associatedData)
    {
        var decryptedData = new byte[cipherText.Length];

        using var aesGcm = new AesGcm(key);
        aesGcm.Decrypt(nonce, cipherText, tag, decryptedData, associatedData);

        return decryptedData;
    }
}