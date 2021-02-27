using System;
using static EncryptionProj.Convert;
using static EncryptionProj.Crypt;

namespace EncryptionProj
{
    class Program
    {
        public static void printArray(string[] input)
        {
            foreach (string x in input)
            {
                Console.Write(x);
                Console.Write(',');
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {

            Console.WriteLine(Decrypt(Encrypt("Thank you Hanzel")));

        }
    }
}
