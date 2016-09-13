using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrangeDoubleTest
{
    [TestClass]
    public class DuplicateDoubleTest
    {

        [TestMethod]
        public void TestMaxValue()
        {
            var target = new DuplicateDouble();

            double result = target.getDouble();

            Assert.IsTrue(result == result + 1);

        }

        [TestMethod]
        public void TestUntillTrue()
        {
            var target = new DuplicateDouble();
            double b = Double.Epsilon;

            while (true)
            {

                if (b == b + 1)
                {
                    break;
                }

                b += 1;

            }
 
        }

    }
}
