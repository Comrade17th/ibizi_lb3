using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibizi_lb3
{
    class Program
    {
        const uint rounds = 12;

        static uint F_function(BitArray input)
        {
            uint result = 0;

            return result;
        }

        static uint XOR_module(BitArray left, BitArray right)
        {
            uint result = 0;

            return result;
        }

        static List<BitArray> GetLeftRight(BitArray input)
        {
            List<BitArray> result = new List<BitArray>();
            
            return result;
        }

        

        static string Encode(string input)
        {
            
            string result = "";

            return result;
        }

        static byte[] stringToByteArr(string input)
        {
            byte[] result = Encoding.UTF8.GetBytes(input);
            return result;
        }

        static string BitArrToStringBits(BitArray input)
        {
            string result = "";
            for(int i = 0; i < input.Length; i++)
            {
                if (i % 8 == 0 && i != 0)
                    result += " ";

                if (input[i])
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }

        static void Main(string[] args)
        {
            string text = "aa";


            BitArray myBA = new BitArray(stringToByteArr(text));
            string some = BitArrToStringBits(myBA);

            
            Console.WriteLine(some);
            Console.ReadKey();
        }
    }
}
