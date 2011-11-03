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
            double side1, side2, side3;
            double angle1, angle2, angle3;
            double longestSide, sumOfOtherSides, semiperimeter;
            double area;

            string triangleSideType;
            string triangleAngleType;



            string[] triSides = CurrentLine.Split(' ');
            side1 = double.Parse(triSides[0]);
            side2 = double.Parse(triSides[1]);
            side3 = double.Parse(triSides[2]);

            longestSide = Math.Max(Math.Max(side1, side2), side3);
            sumOfOtherSides = (side1 + side2 + side3 - longestSide);
            if (side1 < 0 || side2 < 0 || side3 < 0)
            {
                Console.WriteLine("A triangle does not exist with negative side lengths");
                return;
            }

            if (sumOfOtherSides <= longestSide)
            {
                triangleSideType = "is not a triangle";
                triangleAngleType = "";
                area = 0;
                Console.WriteLine("{0} {1} {2} {3}", side1, side2, side2, triangleSideType);
                return;
            }

            semiperimeter = ((side1 + side2 + side3) / 2);
            area = Math.Sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3));

            if (side1 == side2 && side2 == side3)
            {
                triangleSideType = "equilateral";
            }
            else
            {

                if (side1 == side2 || side2 == side3 || side3 == side1)
                {
                    triangleSideType = "isosceles";
                }
                else
                {
                    triangleSideType = "scalene";
                }
            }
            angle1 = (Math.Acos((Math.Pow(side2, 2) + Math.Pow(side3, 2) - Math.Pow(side1, 2)) / (2 * side2 * side3))) * (180 / Math.PI);
            angle2 = (Math.Acos((Math.Pow(side1, 2) + Math.Pow(side3, 2) - Math.Pow(side2, 2)) / (2 * side1 * side3))) * (180 / Math.PI);
            angle3 = (Math.Acos((Math.Pow(side2, 2) + Math.Pow(side1, 2) - Math.Pow(side3, 2)) / (2 * side2 * side1))) * (180 / Math.PI);
            if (angle1 == 90 || angle2 == 90 || angle3 == 90)
            {
                triangleAngleType = "right-angled";
            }
            else
            {
                if (angle1 < 90 && angle2 < 90 && angle3 < 90)
                {
                    triangleAngleType = "acute";
                }
                else
                {
                    triangleAngleType = "obtuse";
                }
            }
            Console.WriteLine("{0} {1} {2} is {3} & {4}. Area = {5}", side1, side2, side2, triangleSideType, triangleAngleType, area);


        }





    }
}
