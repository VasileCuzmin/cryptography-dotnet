using System.Security.Cryptography;
using System.Text;
using AES;

TestAesCbc();
return;

static void TestAesCbc()
{
    const string original = "Text to encrypt";
    var key = RandomNumberGenerator.GetBytes(32);
    var iv = RandomNumberGenerator.GetBytes(16);

    var encrypted = AesEncryption.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
    var decrypted = AesEncryption.Decrypt(encrypted, key, iv);

    var decryptedText = Encoding.UTF8.GetString(decrypted);

    Console.WriteLine("Original text = " + original);
    Console.WriteLine("Encrypted text = " + Convert.ToBase64String(encrypted));
    Console.WriteLine("Decrypted text = " + decryptedText);
}