using ConsoleApp1;
using System;
using Xunit;

namespace Console.Tests
{
    public class CipherTest
    {
        [Theory]
        [InlineData("VTAOG", 2, "TRYME")]
        [InlineData("VGXGPU", 12, "JULUDI")]
        public void Cipher_Encrypt_Sucess(string text, int salt, string expected)
        {
            //Prepare
            var cipher = new Cipher();

            //Act
            var encripted = cipher.Encrypt(text, salt);

            //Assert
            Assert.Equal(expected, encripted);
        }

        [Theory]
        [InlineData("TRYME", 2, "VTAOG")]
        [InlineData("JULUDI", 12, "VGXGPU")]
        public void Cipher_Decrypt_Sucess(string text, int salt, string expected)
        {
            //Prepare
            var cipher = new Cipher();

            //Act
            var decrypted = cipher.Decrypt(text, salt);

            //Assert
            Assert.Equal(expected, decrypted);
        }

        [Theory]
        [InlineData("TRYMEé")]
        [InlineData("JULUDI]")]
        [InlineData(";JULUDI]")]
        [InlineData("ÚJULUDI]")]
        public void Cipher_Decrypt_InvalidCharacter_Exception(string text)
        {
            //Prepare
            var cipher = new Cipher();
            var salt = 2;

            //Act
            Func<string, int, string> decriptFunc = cipher.Decrypt;

            //Assert
            Assert.Throws<Exception>(() => decriptFunc(text, salt));
        }
    }
}