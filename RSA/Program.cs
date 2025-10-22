using System.Text;
using RSA;


NewRSAEncryptDecryptWithKeyExport();

static void NewRSAEncryptDecrypt()
{
    var rsa = new NewRSA();
    string original = "Text to encrypt";

    var encrypted = rsa.Encrypt(original);
    var decrypted = rsa.Decrypt(encrypted);

    Console.WriteLine("Original " + original);
    Console.WriteLine("Encrypted " + Convert.ToBase64String(encrypted));
    Console.WriteLine("Decrypted " + Encoding.Default.GetString(decrypted));
}




// ---
//
// ## 🔒 Summary (Conceptually)
//
//     | Step | Action | Key Used | Purpose |
//     |------|---------|----------|----------|
//     | 1️⃣ | Generate new RSA key pair | — | Create unique keys |
//     | 2️⃣ | Export private key (encrypted) | Private | Backup securely |
//     | 3️⃣ | Export public key | Public | Share freely |
//     | 4️⃣ | Encrypt message | Public | Protect message |
//     | 5️⃣ | Import keys into new object | Both | Restore identity |
//     | 6️⃣ | Decrypt message | Private | Recover original text |
//
//     ---
//
// ## ⚠️ Security Notes
//
//         - The password (`"sadfasdf"`) should be strong and **not hardcoded** in real applications.  
// - Always store the exported private key securely (e.g., file encryption or Azure Key Vault).  
// - Public keys can be distributed safely — they can’t decrypt anything.  
// - You can’t decrypt if you lose the private key or forget the password.
//
//         ---

static void NewRSAEncryptDecryptWithKeyExport()
{
    var rsa = new NewRSA();

    byte[] encryptedPrivateKey = rsa.ExportPrivateKey(10000, "sadfasdf");
    byte[] publicKey = rsa.ExportPublicKey();

    string original = "Text to encrypt";

    var encrypted = rsa.Encrypt(original);

    var rsa2 = new NewRSA();
    rsa2.ImportPublicKey(publicKey);
    rsa2.ImportEncryptedPrivateKey(encryptedPrivateKey, "sadfasdf");

    var decrypted = rsa2.Decrypt(encrypted);
    
    Console.WriteLine("Original " + original);
    Console.WriteLine("Encrypted " + Convert.ToBase64String(encrypted));
    Console.WriteLine("Decrypted " + Encoding.Default.GetString(decrypted));
}