﻿using System;
using System.Collections.Generic;
using System.Text;
using static EncryptionProj.Convert;

namespace EncryptionProj
{
    static class Crypt
    {
        static string Key1 = "";

        private static Random Rando = new Random();
        public static string Encrypt(string input)
        {
            string key = "";
            string strOutput = "";
            string[] output = new string[input.Length];
            int x;
            int y;
            int z;

            string[] conversion = StringToBi(input);

            x = Rando.Next(500, 1555);
            key += x;
            key += '.';
            for (int i = 0; i < conversion.Length;i++)
            {
                y = Int32.Parse(conversion[i]);
                z = x * y;
                output[i] = z.ToString();

                key += z.ToString().Length;
                key += '!';
            }

            for (int i = 0; i < output.Length; i++)
            {
                for (int j = 0; j < output[i].Length; j++)
                {
                    strOutput += output[i][j];
                }
            }

            Key1 = key;
            Console.WriteLine($"The key for your file is: {key}");
            return strOutput;
        }
        public static string Decrypt(string input, string key)
        {
            
            string extract = "";
            string output = "";

            int w = 0;
            int x = 0;
            int y = 0;
            int z = 0;
            int TIC = 0;
            int TI = 0;

            for (int i = 0; i < key.Length; ) {
                while (x == 0)
                {
                    if (key[i] == '.')
                    {
                        x = Int32.Parse(extract);
                        break;
                    }
                    extract += key[i];
                    i++;
                }
                break;
            }
            int countEx = 0;
            for (int i = 0 ; i < key.Length ; i++ )
            {
                if (key[i] == '!')
                {
                    countEx++;
                }
            }
            //New array length of how many parameters, to store binary.
            string[] extractArr = new string[countEx];
            int lc = 0;

            //Extract binary to each array index.
            for (int i = extract.Length; i < key.Length; i++)
            {
                
                extract = "";
                if (key[i] == '!' || key[i] == '.')
                {
                    continue;
                }
                while(key[i] != '!') 
                {
                    extract += key[i];
                    i++;
                }
                z = Int32.Parse(extract);
                extract = "";
                TIC = 0;
                for (int j = 0; j < z  ; j++)
                {
                    extract += input[j + TI];
                    TIC++;
                }
                TI += TIC;

                w = Int32.Parse(extract);
                y = w / x;
                output = y.ToString();
                if (output.Length < 8)
                {
                    output = output.PadLeft(8,'0');
                }

                extractArr[lc] += output;
                
                lc++;
            }


            output = BiToString(extractArr);
            return output;
            //// Console.WriteLine(output);
        }
    }
}
