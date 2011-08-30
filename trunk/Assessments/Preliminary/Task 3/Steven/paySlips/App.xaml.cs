using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace paySlips
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public class globals
    {
        public static int wage;

        public static int publicHoliday;

        public static int overtime;

        public static int totalwage;

        public static double grossResults;

        public static double tax;

        public static int response;

        public static int wageHours;

            
    }
    public partial class App : Application
    {
        public static int value { get; set; }
        
    }
}
