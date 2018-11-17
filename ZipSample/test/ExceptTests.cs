using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        public void Except_integers()
        {
            var first = new List<int> { 1, 4, 3, 5, 4 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 1, 4 };

            var actual = MyLinq.MyExcept(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Except_integers_second()
        {
            var first = new List<int> { 1, 4, 3, 5, 4 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 7, 9 };

            var actual = MyLinq.MyExcept(second, first).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}