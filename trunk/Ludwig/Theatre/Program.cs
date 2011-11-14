using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Theatre
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] seats = new string[8, 10];
            setupSeatsAllUnsold(seats);
            randomlySetSoldSeats(seats, 45);
            printAllSeats(seats);
            printAdjoiningSeats(seats);

        }

        private static void printAdjoiningSeats(string[,] seats)
        {
            throw new NotImplementedException();
        }

        private static void printAllSeats(string[,] seats)
        {
            throw new NotImplementedException();
        }

        private static void randomlySetSoldSeats(string[,] seats, int numberOfSoldSeats)
        {
            throw new NotImplementedException();
        }

        private static void setupSeatsAllUnsold(string[,] seats)
        {
            for (int row = 0; row <= 8; row++)
            {
                for (int seat = 0; seat <= 10; seat++)
                {
                    seats[row, seat] = "unsold";
                }
            }
        }




    }
}
