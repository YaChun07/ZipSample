using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void concat_integers()
        {
            var first = new int[] {1, 3, 5};
            var second = new int[] {2, 4, 6};

            var actual = MyConcat(first, second).ToArray();

            var expected = new int[] {1, 3, 5, 2, 4, 6};
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<int> MyConcat(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEmu = first.GetEnumerator();
            var secondEmu = second.GetEnumerator();

            while (firstEmu.MoveNext())
            {
                yield return firstEmu.Current;
            }
            while (secondEmu.MoveNext())
            {
                yield return secondEmu.Current;
            }
        }
    }
}