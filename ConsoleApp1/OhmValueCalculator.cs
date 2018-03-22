﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        List<ElectronicColorCode> colorCodes;

        public OhmValueCalculator()
        {
            colorCodes = new List<ElectronicColorCode>()
            {
                new ElectronicColorCode() { Color = "Pink", SignificantFigure=0, Multiplier=-3, Tolerance=0 },
                new ElectronicColorCode() { Color = "Silver", SignificantFigure=0, Multiplier=-2, Tolerance=10 },
                new ElectronicColorCode() { Color = "Gold", SignificantFigure=0, Multiplier=-1, Tolerance=5 },
                new ElectronicColorCode() { Color = "Black", SignificantFigure=0, Multiplier=0, Tolerance=0 },
                new ElectronicColorCode() { Color = "Brown", SignificantFigure=1, Multiplier=1, Tolerance=1 },
                new ElectronicColorCode() { Color = "Red", SignificantFigure=2, Multiplier=2, Tolerance=2 },
                new ElectronicColorCode() { Color = "Orange", SignificantFigure=3, Multiplier=3, Tolerance=0 },
                new ElectronicColorCode() { Color = "Yellow", SignificantFigure=4, Multiplier=4, Tolerance=5 },
                new ElectronicColorCode() { Color = "Green", SignificantFigure=5, Multiplier=5, Tolerance=0.5 },
                new ElectronicColorCode() { Color = "Blue", SignificantFigure=6, Multiplier=6, Tolerance=0.25 },
                new ElectronicColorCode() { Color = "Voilet", SignificantFigure=7, Multiplier=7, Tolerance=0.1 },
                new ElectronicColorCode() { Color = "Gray", SignificantFigure=8, Multiplier=8, Tolerance=0.05 },
                new ElectronicColorCode() { Color = "White", SignificantFigure=9, Multiplier=9, Tolerance=0 }
            };
        }

        public ResistanceValues CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            ElectronicColorCode primaryColor = colorCodes.Where(c => c.Color.ToUpper().Equals(bandAColor.ToUpper())).FirstOrDefault();
            ElectronicColorCode secondaryColor = colorCodes.Where(c => c.Color.ToUpper().Equals(bandBColor.ToUpper())).FirstOrDefault();
            ElectronicColorCode multiplierColor = colorCodes.Where(c => c.Color.ToUpper().Equals(bandCColor.ToUpper())).FirstOrDefault();
            ElectronicColorCode toleranceColor = colorCodes.Where(c => c.Color.ToUpper().Equals(bandDColor.ToUpper())).FirstOrDefault();

            long ohmValue = 0;
            long minOhmValue = 0;
            long maxOhmValue = 0;
            double toleranceValue = 0;
           

            if (primaryColor == null)
                return null;

            ohmValue = primaryColor.SignificantFigure;

            if (secondaryColor != null)
                ohmValue = (ohmValue * 10) + secondaryColor.SignificantFigure;

            //calculate Multiplier
            if (multiplierColor != null)
                ohmValue = ohmValue * (Convert.ToInt64(Math.Pow(10, multiplierColor.Multiplier)));

            //calculate tolerance
            if (toleranceColor != null)
            {
                toleranceValue = ohmValue * (toleranceColor.Tolerance) / 100;
            }
            /*else
            {
                toleranceValue = ohmValue * 0.2; // No bnad means 20% tolerance
            }*/

            minOhmValue = ohmValue - Convert.ToInt64(toleranceValue);
            maxOhmValue = ohmValue + Convert.ToInt64(toleranceValue);

            ResistanceValues resistanceValue = new ResistanceValues()
            {
                minValue = Convert.ToInt32(minOhmValue),
                maxValue = Convert.ToInt32(maxOhmValue)
            };

            return resistanceValue;

            ///return Convert.ToInt32(minOhmValue);
        }
    }

    public class ElectronicColorCode
    {
        public string Color { get; set; }
        public long SignificantFigure { get; set; }        
        public double Multiplier { get; set; }
        public double Tolerance { get; set; }
    }

    public class ResistanceValues
    {
        public int minValue { get; set; }
        public int maxValue { get; set; }
    }
}
