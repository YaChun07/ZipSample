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
        public void concat_employee()
        {
            var first = new List<Employee>
            {
                new Employee { Id = 91,Name = "David"}
            };
            var second = new List<Employee>
            {
                new Employee { Id = 1,Name = "David"},
                new Employee { Id = 2,Name = "Tom"}
            };
            var actual = MyConcat(first, second).ToList();

            var expected = new List<Employee>
            {
                new Employee {Id = 91, Name = "David"},
                new Employee {Id = 1, Name = "David"},
                new Employee {Id = 2, Name = "Tom"}
            };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [TestMethod]
        public void concat_integers()
        {
            var first = new int[] {1, 3, 5};
            var second = new int[] {2, 4, 6};

            var actual = MyConcat(first, second).ToArray();

            var expected = new int[] {1, 3, 5, 2, 4, 6};
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<T> MyConcat<T>(IEnumerable<T> first, IEnumerable<T> second)
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