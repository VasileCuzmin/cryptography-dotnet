using System.Security.Cryptography;

namespace DES;

public static class DesEncryption
{
    public static byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.Key = key;
        des.IV = iv;

        return des.EncryptCbc(dataToEncrypt, iv);
    }

    public static byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.Key = key;
        des.IV = iv;
        return des.DecryptCbc(dataToDecrypt, iv);
    }
}