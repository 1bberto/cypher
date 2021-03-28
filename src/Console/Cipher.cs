using System;

namespace ConsoleApp1
{
    public class Cipher
    {
        public LinkedList<char> LinkedListData;

        public Cipher()
        {
            LoadLinkedListData();
        }

        private void LoadLinkedListData()
        {
            LinkedListData = new LinkedList<char>();

            for (var i = 65; i <= 90; i++)
            {
                LinkedListData.Append((char)i);
            }

            LinkedListData.Join();
        }

        public string Encrypt(string text, int salt)
        {
            var encriptedString = string.Empty;

            foreach (var letter in text)
            {
                var node = LinkedListData.FindItem(letter);

                if (node == null)
                {
                    throw new Exception($"{letter} is invalid!");
                }

                encriptedString += GetEncryptedLetter(node, salt);
            }

            return encriptedString;
        }

        public string Decrypt(string text, int salt)
        {
            var dencryptedString = string.Empty;

            foreach (var letter in text)
            {
                var node = LinkedListData.FindItem(letter);

                if (node == null)
                {
                    throw new Exception($"{letter} is invalid!");
                }

                dencryptedString += GetDecryptedLetter(node, salt);
            }

            return dencryptedString;
        }

        public static char GetEncryptedLetter(LinkedListNode<char> node, int salt)
        {
            var currentNode = node;

            for (int i = 0; i < salt; i++)
            {
                currentNode = currentNode.Previous;
            }

            return currentNode.Value;
        }

        public static char GetDecryptedLetter(LinkedListNode<char> node, int salt)
        {
            var currentNode = node;

            for (int i = 0; i < salt; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }
    }
}