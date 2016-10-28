using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brush_Up_calcoletor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brush_Up_calcoletor.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        #region test information

        private Calculate _cal;

        [TestInitialize]
        public void testInitialize()
        {
            _cal = new Calculate(3, 2);
        }
        #endregion

        #region Test Metoder
        [TestMethod()]
        public void AdditionTest()
        {
            _cal.Addition();
            Assert.IsTrue(_cal.Answer == 5);
        }

        [TestMethod()]
        public void SubtractionTest()
        {
            _cal.Subtraction();
            Assert.IsTrue(_cal.Answer == 1);
        }

        [TestMethod()]
        public void MultiplactionTest()
        {
            _cal.Multiplaction();
            Assert.IsTrue(_cal.Answer == 6);
        }

        [TestMethod()]
        public void DivisionTest()
        {
            _cal.Division();
            Assert.IsTrue(_cal.Answer == 1.5);
        } 
        #endregion
    }
}