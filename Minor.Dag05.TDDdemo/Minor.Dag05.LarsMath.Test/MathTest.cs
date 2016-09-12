using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Minor.Dag05.LarsMath.Test
{
    public class MathTest
    {
        [Fact]
        public void Fact1is1Test()
        {
            var target = new Math();

            int result = target.Fact(1);

            Assert.Equal(1, result);
        }

        [Fact]
        public void Fact2is2Test()
        {
            var target = new Math();

            int result = target.Fact(2);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Fact3is6Test()
        {
            var target = new Math();

            int result = target.Fact(3);

            Assert.Equal(6, result);
        }

        [Fact]
        public void Fact0isExceptionTest()
        {
            var target = new Math();

            Exception ex = Assert.Throws<InvalidOperationException>(() => target.Fact(0));

            Assert.Equal(new InvalidOperationException().Message, ex.Message);
        }
    }
}
