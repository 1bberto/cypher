using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cipher = new Cipher();

            Console.WriteLine($"Encrypting VTAOG -> {cipher.Encrypt("VTAOG", 2)}");

            Console.WriteLine($"Decrypting TRYME -> {cipher.Decrypt("TRYME", 2)}");

            Console.ReadKey();
        }
    }
}