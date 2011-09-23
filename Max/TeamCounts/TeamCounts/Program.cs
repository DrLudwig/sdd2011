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
            string fileName = @"TextFile1.txt";

            using (FileStream myFileStream = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(myFileStream))
                {
                    string numberofschoolsstring = reader.ReadLine();
                    string line;
                    int numberofschoolsint = int.Parse(numberofschoolsstring);
                    string[] schoolsdetails = new string[numberofschoolsint];
                    int i = 0;
                    while (i < numberofschoolsint)
                    {
                        line = reader.ReadLine();
                        if (line == null) break;
                        schoolsdetails[i] = line;
                        i++;
                    }
                    for (int count = 0; count < numberofschoolsint; count++)
                    {
                        int numbers = int.Parse(schoolsdetails[count]);
                        Console.Write("{0} participants = ", schoolsdetails[count]);
                        if (numbers == 1)
                        {
                            Console.Write("1 team of one");
                        }
                        else
                        {
                            int numberofthrees = numbers / 3;
                            int remainder= numbers % 3;
                            int numberoftwos = remainder / 2;
                            remainder = remainder % 2;
                            if (remainder == 1)
                            {
                                numberoftwos = 2;
                                remainder = numbers - 4;
                                numberofthrees = remainder / 3;
                                remainder = remainder % 3;
                            }
                            if (remainder == 0)
                            {
                                if (numberofthrees > 1)
                                {
                                    Console.Write("{0} teams of three", numberofthrees);
                                    if (numberoftwos > 0)
                                    {
                                        Console.Write(", ");
                                    }
                                }
                                else if (numberofthrees == 1)
                                {
                                    Console.Write("{0} team of three", numberofthrees);
                                    if (numberoftwos > 0)
                                    {
                                        Console.Write(", ");
                                    }
                                }
                                if (numberoftwos > 1)
                                {
                                    Console.Write("{0} teams of two", numberoftwos);
                                }
                                else if (numberoftwos == 1)
                                {
                                    Console.Write("{0} team of two", numberoftwos);
                                }
                            }
                            else
                            {
                                numberoftwos = 1;
                                remainder = numbers - 2;
                                numberofthrees = remainder / 3;
                                remainder = remainder % 3;
                                if (remainder == 0)
                                {
                                    if (numberofthrees > 1)
                                    {
                                        Console.Write("{0} teams of three", numberofthrees);
                                        if (numberoftwos > 0)
                                        {
                                            Console.Write(", ");
                                        }
                                    }
                                    else if (numberofthrees == 1)
                                    {
                                        Console.Write("{0} team of three", numberofthrees);
                                        if (numberoftwos > 0)
                                        {
                                            Console.Write(", ");
                                        }
                                    }
                                    if (numberoftwos > 1)
                                    {
                                        Console.Write("{0} teams of two", numberoftwos);
                                    }
                                    else if (numberoftwos == 1)
                                    {
                                        Console.Write("{0} team of two", numberoftwos);
                                    }
                                }
                            }
                        }
                        Console.WriteLine();

                    }
                }
                
            }
            Console.ReadLine();
        }
    }
}
