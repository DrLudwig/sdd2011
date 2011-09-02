using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateRandomArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Random Array  ");
            int count = 0;
            int highindex = 5;
            int[] myArr = new int[99];
            while (count < highindex)
            {
                count++;
                myArr[count] = count;               
            }
        }
    }
}
