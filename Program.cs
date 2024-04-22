using System;
using System.Text;

namespace EmailEncryptionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Encrypt a message");
                Console.WriteLine("2. Decrypt a message");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Please enter the message you want to encrypt:");
                    string original = Console.ReadLine();

                    byte[] key = Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef"); // 32 bytes key
                    byte[] iv = Encoding.UTF8.GetBytes("0123456789abcdef"); // 16 bytes IV

                    byte[] encrypted = EmailEncryption.Encrypt(original, key, iv);
                    Console.WriteLine("Encrypted message: {0}", Convert.ToBase64String(encrypted));
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Please enter the encrypted message:");
                    string encryptedMessage = Console.ReadLine();

                    byte[] cipherText = Convert.FromBase64String(encryptedMessage);
                    byte[] key = Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef"); // 32 bytes key
                    byte[] iv = Encoding.UTF8.GetBytes("0123456789abcdef"); // 16 bytes IV

                    string decrypted = EmailEncryption.Decrypt(cipherText, key, iv);
                    Console.WriteLine("Decrypted message: {0}", decrypted);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
