using System.Security.Cryptography;

for (var i = 0; i < 10; i++)
{
    var randomNumbers = RandomNumberGenerator.GetBytes(32);
    Console.WriteLine("Random number " + i + " : " + Convert.ToBase64String(randomNumbers));
}

Console.ReadLine();