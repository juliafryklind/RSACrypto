using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // Genererar RSA nyckelpar
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Kryptera och dekryptera meddelande
            string originalMessage = Console.ReadLine();
            byte[] encryptedMessage = EncryptMessage(originalMessage, rsa);
            string decryptedMessage = DecryptMessage(encryptedMessage, rsa);

            Console.WriteLine("Ursprungliga meddelandet: " + originalMessage);
            Console.WriteLine("Krypterat meddelandde: " + Convert.ToBase64String(encryptedMessage));
            Console.WriteLine("Dekrypterat meddelande:: " + decryptedMessage);
        }

        Console.ReadLine();
    }
  //metod för att kryptera meddelande
    static byte[] EncryptMessage(string message, RSACryptoServiceProvider rsa)
    {
        byte[] encodedMessage = Encoding.UTF8.GetBytes(message);
        byte[] encryptedMessage = rsa.Encrypt(encodedMessage, true);

        return encryptedMessage; //returnera meddelande
    }

  //metod för att dekryptera meddelande
    static string DecryptMessage(byte[] encryptedMessage, RSACryptoServiceProvider rsa)
    {
        byte[] decryptedMessage = rsa.Decrypt(encryptedMessage, true);
        string originalMessage = Encoding.UTF8.GetString(decryptedMessage);

        return originalMessage; //returna meddelande
    }
}
