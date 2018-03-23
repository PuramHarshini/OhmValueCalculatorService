using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmValueCalcSvc
{
    class Program
    {
        static void Main(string[] args)
        {
            WhatMyResistance();
            Console.ReadLine();
        }

        private static void WhatMyResistance()
        {
            try
            {
                IOhmValueCalculator ohmValueCalculator = new OhmValueCalculator();
                Console.WriteLine(ohmValueCalculator.CalculateOhmValue("YELLOW", "VOILET", "RED", "GOLD"));                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
