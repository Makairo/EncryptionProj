using System;
using System.Collections.Generic;
using System.Text;
using static EncryptionProj.Convert;
using static EncryptionProj.Crypt;

namespace EncryptionProj
{
    public class UserInterface
    {
        public static void printArray(string[] input)
        {
            foreach (string x in input)
            {
                Console.Write(x);
            }
            Console.Write("\n");
        }
        public static string GetUserString() => Console.ReadLine();

        public static void UserInDecrypt()
        {
            string input;
            string output;
            bool isHash = false;
            Console.WriteLine($"Please enter the message you'd like to decrypt: ");
            input = GetUserString();
            Console.WriteLine($"\n**REGISTERING**\n");
            for (int i = 0; i < input.Length ; i++)
            {
                if (input[i] == '1' || input[i] == '0')
                {
                    continue;
                }
                else
                {
                    isHash = true;
                }
            }

            //Hash Return
            if (isHash == true)
            {
                string inKey = "";
                Console.WriteLine($"Please enter your key: ");
                inKey = GetUserString();
                Console.WriteLine($"\n**DECRYPTING**\n");
                output = Decrypt(input, inKey);
                Console.WriteLine($"Message: {output}");
                return;
            }

            //Binary Return
            Console.WriteLine($"\n**DECRYPTING**\n");
            int inCharLength = input.Length / 8;
            string extract = "";
            string[] inputArr = new string[inCharLength];
            for (int i = 0; i < inCharLength; i++ )
            {
                for (int j = i * 8 ; j < (i * 8) + 8 ; j++)
                {
                    extract += input[j];
                }
                inputArr[i] = extract;
                extract = "";
            }

            output = BiToString(inputArr);
            Console.WriteLine($"Message: {output}");
        }
        public static void UserInEncrypt()
        {
            string input = "";
            string choice = "";

            Console.WriteLine($"Please enter a message you'd like to encrypt: ");
            input = GetUserString();
            
            while (choice != "B" && choice != "H" && choice != "b" && choice != "h")
            {
                Console.WriteLine($"Binary or Hash? (B / H) : ");
                choice = GetUserString();
            }

            Console.WriteLine($"\n**ENCRYPTING**\n");


            if (choice == "B" || choice == "b")
            {
                string[] output = StringToBi(input);
                Console.WriteLine($"Binary Message: ");
                printArray(output);
                return;
            }
            if (choice == "H" || choice == "h")
            {
                string output = Encrypt(input);
                Console.WriteLine($"Hash Message: {output}");
                return;
            } 

        }


    }
}
