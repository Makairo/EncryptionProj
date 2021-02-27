using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionProj
{
    public class Convert
    {
        public static string CharToBi(char X)
        {
            string output = "";

            int Y = (int)X;

            if (Y / 128 >= 1)
            {
                output += '1';
                Y -= 128;
            }
            else
            {
                output += '0';
            }

            if (Y / 64 >= 1)
            {
                output += '1';
                Y -= 64;
            }
            else
            {
                output += '0';
            }

            if (Y / 32 >= 1)
            {
                output += '1';
                Y -= 32;
            }
            else
            {
                output += '0';
            }

            if (Y / 16 >= 1)
            {
                output += '1';
                Y -= 16;
            }
            else
            {
                output += '0';
            }

            if (Y / 8 >= 1)
            {
                output += '1';
                Y -= 8;
            }
            else
            {
                output += '0';
            }

            if (Y / 4 >= 1)
            {
                output += '1';
                Y -= 4;
            }
            else
            {
                output += '0';
            }

            if (Y / 2 >= 1)
            {
                output += '1';
                Y -= 2;
            }
            else
            {
                output += '0';
            }

            if (Y / 1 >= 1)
            {
                output += '1';
                Y -= 1;
            }
            else
            {
                output += '0';
            }


            return output;
        }
        public static char BiToChar(string input)
        {
            int output = 0;
            int Y = 128;
            char outP = ' ';
            for (int i = 0; i < input.Length ; i++ )
            {
                
                if (input[i] == '1')
                {
                    output += Y;
                }
                Y /= 2;
            }
            outP = (char)output;
            if (output == '@')
            {
                outP = ' ';
            }
            return outP;
        }
        public static string[] StringToBi(string input)
        {
            string[] output = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = CharToBi(input[i]);
            }
            return output;
        }
        public static string BiToString(string[] input)
        {
            string output = "";
            for(int i = 0 ; i < input.Length ; i++)
            {
                output += BiToChar(input[i]);
            }
            return output;
        }
    }
}
