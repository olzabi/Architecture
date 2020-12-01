using System;
using System.Collections;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Task_2
{
    class Program
    {
        // ColorPrint() принимает в себя строку и индексы, которые нам нужны.
        static void ColorPrint(string s, int[] colorIndexes)
        {
            for (int i = 0; i < s.Length; i++) {
                if (colorIndexes.Contains(s.Length - i - 1)) 
                    Console.ForegroundColor = ConsoleColor.Red; 
                else
                    Console.ResetColor(); 
                Console.Write(s[i]); 
            }
            Console.WriteLine();
        }
        static string ToOctet(int a)
        { // doing convert to binary base, filling with 0 on the left side
            return Convert.ToString(a, 2).PadLeft(8, '0');
        }
 
        static void Main(string[] args)
        {
            //  point 1 --> input byte in decimal format
            Console.Write("Enter a number between 0 and 255: ");
            int bin;
            if (!int.TryParse(Console.ReadLine(), out bin)) {
                bin = 200;
            }
            bin %= 256;
            
            //  toBIN
            string stringBin = ToOctet(bin);
            
            // Output bin  
            Console.WriteLine("{0}(10)={1}(2)", bin, stringBin);
            
            // Color bit 7 and bit 4
            ColorPrint(stringBin, new int[]{4,7});
            
            // Inversed
            int inversed = ~bin & 0xFF;
            
            // output inversed binary 
            Console.WriteLine("Decimal form of inversed binary: {0}", inversed);
            Console.WriteLine("Binary form of inversed binary: {0}", ToOctet(~bin & 0xFF));
            
            
            // Merge bin and binInversed(?)
            Console.WriteLine("Merged original byte and inversed one in decimal form: {0}", bin + inversed);
            Console.WriteLine("Merged original byte and inversed one in binary form: {0}", ToOctet(bin + inversed));

            // end of task
            Console.ReadKey();
        }
    }
}