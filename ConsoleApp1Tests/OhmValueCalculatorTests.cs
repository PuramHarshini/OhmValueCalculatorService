using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmValueCalcSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmValueCalcSvc.Tests
{
    [TestClass()]
    public class OhmValueCalculatorTests
    {
        IOhmValueCalculator ohmCalcService;

        [TestInitialize]
        public void Setup()
        {
            //setup data
            ohmCalcService = new OhmValueCalculator();            
        }

        [TestCleanup]
        public void Cleanup()
        {
            //cleanup
            ohmCalcService = null;
        }

        /// <summary>
        /// Test method passing all the values of the resistor band
        /// </summary>
        [TestMethod()]
        public void CalculateOhmValuePositiveTest()
        {
            string bandAClr = "Yellow";
            string bandBclr = "Voilet";
            string bandCclr = "Red";
            string bandDclr = "Gold";               

            ResistanceValues actualValue = ohmCalcService.CalculateOhmValue(bandAClr,bandBclr,bandCclr,bandDclr);

            Assert.AreEqual(4465, actualValue.minValue);
            Assert.AreEqual(4935,actualValue.maxValue);
        }

        /// <summary>
        /// Test method passing none the values of the resistor band
        /// </summary>
        [TestMethod()]
        public void CalculateOhmValueNegativeTest()
        {
            string bandAClr = "";
            string bandBclr = "";
            string bandCclr = "";
            string bandDclr = "";

            ResistanceValues actualValue = ohmCalcService.CalculateOhmValue(bandAClr, bandBclr, bandCclr, bandDclr);
            
            Assert.AreEqual(0, actualValue.minValue);
            Assert.AreEqual(0, actualValue.maxValue);
        }

        /// <summary>
        /// Test method passing only the primary color of the resistor band
        /// </summary>
        [TestMethod()]
        public void CalculateOhmValueOnlyPrimaryClrTest()
        {
            string bandAClr = "Yellow";
            string bandBclr = "";
            string bandCclr = "";
            string bandDclr = "";

            ResistanceValues actualValue = ohmCalcService.CalculateOhmValue(bandAClr, bandBclr, bandCclr, bandDclr);

            Assert.AreEqual(4,actualValue.maxValue, actualValue.minValue);
        }

        /// <summary>
        /// Test method without passing the secondary color of the resistor band
        /// </summary>
        [TestMethod()]
        public void CalculateOhmValueNoSecondaryClrTest()
        {
            string bandAClr = "Yellow";
            string bandBclr = "";
            string bandCclr = "Red";
            string bandDclr = "Gold";

            ResistanceValues actualValue = ohmCalcService.CalculateOhmValue(bandAClr, bandBclr, bandCclr, bandDclr);

            Assert.AreEqual(380, actualValue.minValue);
            Assert.AreEqual(420, actualValue.maxValue);
        }

        /// <summary>
        /// Test method for a Zero resisitance band
        /// </summary>
        [TestMethod()]
        public void CalculateOhmValueForABlackBandTest()
        {
            string bandAClr = "Black";
            string bandBclr = "";
            string bandCclr = "";
            string bandDclr = "";
            
            ResistanceValues actualValue = ohmCalcService.CalculateOhmValue(bandAClr, bandBclr, bandCclr, bandDclr);

            Assert.AreEqual(0,actualValue.minValue,actualValue.maxValue);
        }
    }
}