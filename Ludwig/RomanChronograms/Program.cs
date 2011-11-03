using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfLines;
            string[] lines = System.IO.File.ReadAllLines(@"TextFile1.txt");

            NumberOfLines = int.Parse(lines[0]);

            int i = 0;
            while (i < NumberOfLines)
            {
                string CurrentLine = lines[i + 1];
                i++;
                Calculate(CurrentLine);
            }

            Console.ReadLine();
        }

        private static void Calculate(string CurrentLine)
        {
            char[] letters = CurrentLine.ToCharArray();
            int total = 0;
            foreach (char ch in letters)
            {
                if (ch == 'M')
                {
                    total += 1000;
                }
            }

            Console.WriteLine(CurrentLine);

        }





    }
}
