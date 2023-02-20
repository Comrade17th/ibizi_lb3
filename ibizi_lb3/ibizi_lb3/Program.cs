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

        static BitArray F_function(BitArray input, BitArray key)
        {

            BitArray ba1;
            BitArray ba2;
            ResizeBitArrays(input, key, out ba1, out ba2);
            BitArray result = new BitArray(ba1);
            result.Or(ba2);
            return result;
        }

        static void ResizeBitArrays(BitArray ba1, BitArray ba2, out BitArray ba1_out, out BitArray ba2_out)
        {
            int maxsize = Math.Max(ba1.Length, ba2.Length);
            int minsize = Math.Min(ba1.Length, ba2.Length);
            int j = 0;
            if(ba1.Length > ba2.Length)
            {
                ba1_out = ba1;
                bool[] ba2_temp = new bool[maxsize];
                for(int i = 0; i < maxsize; i++)
                {
                    if (i < maxsize - minsize + 1)
                        ba2_temp[i] = false;
                    ba2_temp[i] = ba2[j];
                    j++;
                }
                ba2_out = new BitArray(ba2_temp);
            }
            else
            {
                ba2_out = ba2;
                bool[] ba1_temp = new bool[maxsize];
                for (int i = 0; i < maxsize; i++)
                {
                    if (i < maxsize - minsize + 1)
                        ba1_temp[i] = false;
                    ba1_temp[i] = ba1[j];
                    j++;
                }
                ba1_out = new BitArray(ba1_temp);
            }

        }

        static BitArray XOR_module(BitArray left, BitArray right)
        {
            BitArray result = left;
            result.Xor(right);
            return result;
        }

        static BitArray unitBlock(BitArray left, BitArray right, BitArray key)
        {
            BitArray result = left;
            BitArray temp = new BitArray(F_function(right, key));
            result.Xor(temp);
            return result;
        }

        static List<BitArray> GetLeftRight(BitArray input)
        {
            List<BitArray> result = new List<BitArray>();
            bool[] left = new bool[input.Length / 2];
            bool[] right = new bool[input.Length / 2];
            for (int i = 0; i < input.Length; i++)
            {
                if (i < input.Length / 2)
                {
                    left[i] = input[i];
                }
                else
                {
                    right[i - input.Length / 2] = input[i];
                }                       
            }
            result.Add(new BitArray(left));
            result.Add(new BitArray(right));
            return result;
        }

        

        static string Encode(string input, string key_string)
        {
            string result = "";
            BitArray key = new BitArray(stringToByteArr(key_string));
            List<BitArray> listBA = new List<BitArray>(GetLeftRight(stringToBitArray(input)));
            BitArray left = listBA[0];
            BitArray right = listBA[1];
            for (int i = 0; i < rounds; i++)
            {
                BitArray temp = new BitArray(unitBlock(left, right, key));
                left = right;
                right = temp;
            }
            BitArray union = new BitArray(uniteBitArr(right, left));
            result = BitArrToStringBits(union);
            return result;
        }

        static BitArray uniteBitArr(BitArray left, BitArray right)
        {
            bool[] temp = new bool[left.Length + right.Length];
            for(int i = 0; i < temp.Length; i++)
            {
                if(i < left.Length / 2)
                    temp[i] = left[i];
                else
                    temp[i] = right[i];
            }

            BitArray result = new BitArray(temp);
            return result;
        }

        static byte[] stringToByteArr(string input)
        {
            byte[] result = Encoding.UTF8.GetBytes(input);
            return result;
        }

        static BitArray stringToBitArray(string input)
        {
            BitArray result = new BitArray(stringToByteArr(input));
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

        static string stringToBitString(string input)
        {
            string result = "";
            BitArray temp = new BitArray(stringToBitArray(input));
            result = BitArrToStringBits(temp);
            return result;
        }

        static void encodeTest()
        {
            string text = "hello";
            Console.WriteLine(text + "Исходный текст в битах");
            Console.WriteLine(stringToBitString(text));
            string key = "key";
            string result = Encode(text, key);
            Console.WriteLine("Закодированный текст в битах");
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {

            encodeTest();
            Console.ReadKey();
        }

    }
}
