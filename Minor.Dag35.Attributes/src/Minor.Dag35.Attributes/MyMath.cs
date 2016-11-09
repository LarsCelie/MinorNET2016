using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag35.Attributes
{
    public class MyMath
    {
        [Test(25, Output = 5)]
        [Test(-25, ExpectedException = "ArgumentOutOfRangeException")]
        [Test(25, Output = 1)]
        protected internal int SquareRootInt(int n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException();
            return (int)Math.Sqrt((double)n);
        }

        [Test(2.0, 3.0, Output = 2.5)]
        [Test(12.5, 15.0, Output = 13.75)]
        public static double Average(double a, double b)
        {
            return (a + b) / 2;
        }
    }
}
