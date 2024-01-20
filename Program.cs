using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoalphabeticCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MonoalphabeticCipher();
        }

        private static void MonoalphabeticCipher()
        {
            char[] a = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Write(alphabet);
            char[] rnd_alphabet = new char[alphabet.Length];
            rnd_alphabet = RandomizeArray(a, 26);
            Write(rnd_alphabet);
            Console.WriteLine();
            Console.WriteLine("Introduceti textul pentru criptare:");
            string plainText = Console.ReadLine();
            string cipherText = MonoalphabetiEncrypt(plainText, alphabet, rnd_alphabet);
            Console.WriteLine($"Encrypted:{cipherText}.");
            string decryptedText = MonoalphabeticDecrypt(cipherText, alphabet, rnd_alphabet);
            Console.WriteLine($"Decrypted:{decryptedText}.");
            Console.ReadKey();

        }

        private static void Write(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }

        private static string MonoalphabeticDecrypt(string cipherText, char[] alphabet, char[] rnd_alphabet)
        {
            string plainText = "";
            foreach (char c in cipherText)
            {
                if (char.IsLetter(c))
                {
                    char upperC = char.ToUpper(c);
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (rnd_alphabet[i] == upperC)
                        {
                            upperC = alphabet[i];
                            break;
                        }
                    }
                    plainText += upperC;
                }
                else
                {
                    plainText += c;
                }
            }
            return plainText;
        }

        private static string MonoalphabetiEncrypt(string plainText, char[] alphabet, char[] rnd_alphabet)
        {
            string cipherText = "";
            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    char upperC = char.ToUpper(c);
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (upperC == alphabet[i])
                        {
                            upperC = rnd_alphabet[i];
                            break;
                        }
                    }
                    cipherText += upperC;
                }
                else
                {
                    cipherText += c;
                }
            }
            return cipherText;

        }

        private static char[] RandomizeArray(char[] a, int length)
        {
            //shuffling the array using "Fisher–Yates shuffle Algorithm"
            char[] array = a;
            Random rnd = new Random();
            for (int i = length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }

    }
}

