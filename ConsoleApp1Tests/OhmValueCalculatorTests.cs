using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class OhmValueCalculatorTests
    {
        [TestMethod()]
        public void CalculateOhmValuePositiveTest()
        {
            string bandAClr = "Yellow";
            string bandBclr = "Voilet";
            string bandCclr = "Red";
            string bandDclr = "Gold";

            OhmValueCalculator resistanceValue = new OhmValueCalculator();

            ResistanceValues actualValue = new ResistanceValues()
            {
                minValue = 0,
                maxValue = 0
            };

            actualValue = resistanceValue.CalculateOhmValue(bandAClr,bandBclr,bandCclr,bandDclr);

            Assert.AreEqual(4465, actualValue.minValue);
            Assert.AreEqual(4935,actualValue.maxValue);
        }

        [TestMethod()]
        public void CalculateOhmValueNegativeTest()
        {
            string bandAClr = "";
            string bandBclr = "";
            string bandCclr = "";
            string bandDclr = "";

            OhmValueCalculator resistanceValue = new OhmValueCalculator();

            ResistanceValues actualValue = new ResistanceValues()
            {
                minValue = 0,
                maxValue = 0
            };

            actualValue = resistanceValue.CalculateOhmValue(bandAClr, bandBclr, bandCclr, bandDclr);
            
            Assert.AreEqual(null, actualValue);
        }

        [TestMethod()]
        public void CalculateOhmValueOnlyPrimaryClrTest()
        {
            string bandAClr = "Black";
            string bandBclr = "";
            string bandCclr = "";
            string bandDclr = "";

            OhmValueCalculator resistanceValue = new OhmValueCalculator();

            ResistanceValues actualValue = new ResistanceValues()
            {
                minValue = 0,
                maxValue = 0
            };

            actualValue = resistanceValue.CalculateOhmValue(bandAClr, bandBclr, bandCclr, bandDclr);

            Assert.AreEqual(actualValue.maxValue, actualValue.minValue);
        }

        [TestMethod()]
        public void CalculateOhmValueNoSecondaryClrTest()
        {
            string bandAClr = "Yellow";
            string bandBclr = "";
            string bandCclr = "Red";
            string bandDclr = "Gold";

            OhmValueCalculator resistanceValue = new OhmValueCalculator();

            ResistanceValues actualValue = new ResistanceValues()
            {
                minValue = 0,
                maxValue = 0
            };

            actualValue = resistanceValue.CalculateOhmValue(bandAClr, bandBclr, bandCclr, bandDclr);

            Assert.AreEqual(380, actualValue.minValue);
            Assert.AreEqual(420, actualValue.maxValue);
        }
    }
}