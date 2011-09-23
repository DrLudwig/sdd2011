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
                        int numberofthrees = numbers / 3;
                        numbers = numbers % 3;
                        int numberoftwos = numbers / 2;
                        numbers = numbers % 2;
                        int numberofones = numbers;
                        Console.Write("{0} participants = ", schoolsdetails[count]);
                        if (numberofthrees > 1)
                        {
                            Console.Write("{0} teams of three", numberofthrees);
                            if (numberoftwos > 0)
                            {
                                Console.Write(", ");
                            }
                            else if (numberofones > 0)
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
                            else if (numberofones > 0)
                            {
                                Console.Write(", ");
                            }
                        }
                        if (numberoftwos > 1)
                        {
                            Console.Write("{0} teams of two", numberoftwos);
                            if (numberofones > 0)
                            {
                                Console.Write(", ");
                            }
                        }
                        else if (numberoftwos == 1)
                        {
                            Console.Write("{0} team of two", numberoftwos);
                            if (numberofones > 0)
                            {
                                Console.Write(", ");
                            }
                        }
                        if (numberofones > 1)
                        {
                            Console.Write("{0} teams of one", numberofones);
                        }
                        else if (numberofones == 1)
                        {
                            Console.Write("{0} team of one", numberofones);
                        }
                        Console.WriteLine();
                    }
                }
                
            }
            Console.ReadLine();
        }
    }
}
