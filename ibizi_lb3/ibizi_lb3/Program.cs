using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibizi_lb3
{
    class Program
    {
        static void write(uint input)
        {
            string code = Convert.ToString(input, 2);
            string res = "";
            for(int i = 0; i < 8 - code.Length; i++)
            {
                res += "0";
            }
            res += code;
            Console.WriteLine(res);
        }
        static void Main(string[] args)
        {
            uint a = 0b_0000_0101;
            uint b = 0b_0000_0011;
            uint res1 = a ^ b;
            uint res2 = a | b;
            uint res3 = a & b;
            write(a);
            write(b);
            write(res1);
            write(res2);
            write(res3);
            Console.ReadKey();
        }
    }
}
