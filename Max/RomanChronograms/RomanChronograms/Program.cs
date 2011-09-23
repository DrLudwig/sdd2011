using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RomanChronograms
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"TextFile1.txt";
            using (FileStream myFileStream = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(myFileStream))
                {
                    string numberoflinesstring = reader.ReadLine();
                    int numberoflines = int.Parse(numberoflinesstring);
                    string[] Chronograms = new string[numberoflines];
                    string line;
                    int i = 0;
                    int total = 0;
                    while (i < numberoflines)
                    {
                        line = reader.ReadLine();
                        if (line == null) break;
                        Chronograms[i] = line;
                        i++;
                    }
                    for (int a = 0; a < numberoflines; a++)
                    {
                        for (int b = 0; b < Chronograms[a].Length; b++)
                        {
                            string letter = Chronograms[a].Substring(b, 1);
                            if (letter == "M")
                            {
                                total = total + 1000;
                            }
                            else if (letter == "D")
                            {
                                total = total + 500;
                            }
                            else if (letter == "C")
                            {
                                total = total + 100;
                            }
                            else if (letter == "L")
                            {
                                total = total + 50;
                            }
                            else if (letter == "X")
                            {
                                total = total + 10;
                            }
                            else if (letter == "V")
                            {
                                total = total + 5;
                            }
                            else if (letter == "I")
                            {
                                total = total + 1;
                            }
                        }
                        Console.WriteLine("{0} {1}", total, Chronograms[a]);
                        total = 0;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
