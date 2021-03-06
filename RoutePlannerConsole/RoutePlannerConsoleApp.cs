﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Routeplanner (Version {0})", Assembly.GetExecutingAssembly().GetName().Version);

            try
            {
                var cities = new Cities();
                cities.ReadCities("data/citiesTestDataLab4.txt");
            }
            catch (Exception)
            {
                //throw;
            }
            

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
        
    }
}
