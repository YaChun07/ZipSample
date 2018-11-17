using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void pair_3_girls_and_5_boys()
        {
            var girls = Repository.Get3Girls();
            var keys = Repository.Get5Keys();

            var girlAndBoyPairs = MyZip(girls, keys).ToList();
            var expected = new List<Tuple<string, string>>
            {
                Tuple.Create("Jean", "Joey"),
                Tuple.Create("Mary", "Frank"),
                Tuple.Create("Karen", "Bob"),
            };

            expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
        }
        [TestMethod]
        public void pair_3_boys_and_5_girls()
        {
            var girls = Repository.Get5Girls();
            var keys = Repository.Get3Keys();

            var girlAndBoyPairs = MyZip2(keys,girls).ToList();
            var expected = new List<Tuple<string, string>>
            {
                Tuple.Create("Jean", "Joey"),
                Tuple.Create("Mary", "Frank"),
                Tuple.Create("Karen", "Bob"),
            };

            expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
        }

        private IEnumerable<Tuple<string,string>> MyZip2(IEnumerable<Key> keys, IEnumerable<Girl> girls)
        {
            var first = keys.GetEnumerator();
            var second = girls.GetEnumerator();
            while (first.MoveNext()&&second.MoveNext())
            {
                yield return Tuple.Create(second.Current.Name, first.Current.OwnerBoy.Name);
            }
        }

        private IEnumerable<Tuple<string, string>> MyZip(IEnumerable<Girl> girls, IEnumerable<Key> keys)
        {
            var girlEmu = girls.GetEnumerator();
            var keyEmu = keys.GetEnumerator();
            while (keyEmu.MoveNext() && girlEmu.MoveNext())
            {
                //yield return new Tuple<string, string>(girlEmu.Current.Name, keyEmu.Current.OwnerBoy.Name);
                yield return Tuple.Create(girlEmu.Current.Name, keyEmu.Current.OwnerBoy.Name);
            }
            //var girl = girls.ToArray();
            //var key = keys.ToArray();
            //var minLength = Math.Min(girl.Length,key.Length);
            //for (var i = 0; i < minLength; i++)
            //{
            //    yield return Tuple.Create(girl[i].Name, key[i].OwnerBoy.Name);
            //}
        }
    }
}