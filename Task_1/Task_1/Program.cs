using System;
using System.IO;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        //  reads an input line and returns converted to byte value  
        static byte Input() {
            return Convert.ToByte(Console.ReadLine());
            
        }
        
        //  returns string with converted decimal number to binary 
        static string DecToBin(int number) {
            return Convert.ToString(number, 2).PadLeft(8, '0');
        }
        
        // returns decimal number from binary
        static int BinToDec(int number)
        {
            int num = number;
            int decValue = 0;

            int base1 = 1;

            int temp = num;
            while (temp > 0) {
                int lastDigit = temp % 10;
                temp = temp / 10;
                decValue += lastDigit * base1;
                base1 = base1 * 2;
            }
            return decValue;
        }
        
        // count is used for condition of reading bytes
        static byte Count()
        {

            byte byteCounter = Input();

            if (byteCounter >= 1 && byteCounter <= 26)
            {
                return byteCounter;
            }
            else if (byteCounter > 26)
            {
                byteCounter = 26;
                return byteCounter;
            }
            else
            {
                byteCounter = 10;
                return byteCounter;
            }
        }


        static void Main(string[] args)
        {
            //  path
            Console.WriteLine(@"Введите путь к файлу:"); // c:\your_path\file
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string path = Console.ReadLine(); 
            Console.ResetColor();


            //  path - check
            string message = (File.Exists(path)) ? "Проверка - ОК" : "Проверка - Файл не существует";
            Console.WriteLine(message);
            Console.ReadLine();

            // byte input
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Введите количество байтов (3-30): "); // my input - 6
            byte count = Count();
            Console.ResetColor();


            List<byte> byteFromDecList = new List<byte>();
            List<string> binFromByteList = new List<string>();

            // reads a string from file
            using (StreamReader sr = new StreamReader(path))
            {
                
                // string needed -> 28 1 171 191 71 192 
                string data = sr.ReadLine();
                string[] numbers = data.Split(new char[] {' '});
                
                byte countFileBytes = 0;
                foreach (string number in numbers)
                {
                    countFileBytes++;
                }
                
                // checking if input data is ok 
                if (countFileBytes == count)
                {
                    // convert our string in bytes, then binary DEC --> BYTE --> BIN
                    foreach (string number in numbers) {   
                        byte b = Convert.ToByte(number);
                        byteFromDecList.Add(b);
                        string bin = DecToBin(b);
                        binFromByteList.Add(bin);
                    }
                } else {
                    Console.WriteLine($"Bytes counter in file :{countFileBytes} != Byte counter: {count}");
                }
            }
            
            //  byte order
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("Последовательность байт:");
            Console.ResetColor(); 
            
            // output byte order
            for (int i = 0; i < byteFromDecList.Count; i++) {
                Console.Write(byteFromDecList[i] + " ");
            }
            
            // binary order
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nБинарная последовательность: ");
            Console.ResetColor(); 
            
            // output binary order 
            for (int i = 0; i < binFromByteList.Count; i++) {
                Console.Write(binFromByteList[i] + " ");
            }

            //  RIGHT SHIFT 2  
            List<int> decFromByteList2Shift = new List<int>();
            List<string> binFromByteList2Shift = new List<string>();
            
            //  shift 2
            for (byte i = 0; i < byteFromDecList.Count; i++) {
                byte tmp = byteFromDecList[i];
                int shifted = tmp >> 2;
                decFromByteList2Shift.Add(shifted);
                string shiftedBin = DecToBin(shifted);
                binFromByteList2Shift.Add(shiftedBin);
            }
            
            // output right shift
            // 7 0 42 47 17 48
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("\nСдвиг вправо -> на 2 бита: ");
            Console.ResetColor(); // сбрасываем в стандартный

            // output shifted binary line with highlighting & counting EVEN numbers
            int evenNumCounter = 0;
            for (int i = 0; i < binFromByteList2Shift.Count; i++)
            {
                int decNum = BinToDec(Convert.ToInt32(binFromByteList2Shift[i]));
                if (decNum % 2 == 0) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{binFromByteList2Shift[i]}" + " ");
                    Console.ResetColor();
                    evenNumCounter++;
                }
                else {
                    Console.Write($"{binFromByteList2Shift[i]}" + " ");
                }
            }
            
            // output even counter
            Console.WriteLine("\nКоличество байт, имеющих четное значение: {0}", evenNumCounter );
            Console.ReadLine();
        }
    }
}
