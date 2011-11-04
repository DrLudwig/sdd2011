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
            string[] lines = System.IO.File.ReadAllLines(@"TextFile1.txt");
            int numberoflines = int.Parse(lines[0]);
            int total = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                char[] characters = lines[i].ToCharArray();

                for (int a = 0; a < characters.Length; a++)
                {
                    switch (characters[a])
                    {
                        case 'M':
                            total = total + 1000;
                            break;
                        case 'D':
                            total = total + 500;
                            break;
                        case 'C':
                            total = total + 100;
                            break;
                        case 'L':
                            total = total + 50;
                            break;
                        case 'X':
                            total = total + 10;
                            break;
                        case 'V':
                            total = total + 5;
                            break;
                        case 'I':
                            total++;
                            break;
                    }
                }
                Console.WriteLine("{0} {1}", total, lines[i]);
                total = 0;
            }
            Console.ReadLine();
        }
    }
}
