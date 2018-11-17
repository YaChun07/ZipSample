using System;
using System.Collections.Generic;

namespace ZipSample.test
{
    public class MyEqualityCompare : EqualityComparer<Girl>
    {
        public override bool Equals(Girl x, Girl y)
        {
            return x.Name == y.Name;
        }

        public override int GetHashCode(Girl obj)
        {
            return Tuple.Create(obj.Name).GetHashCode();
        }
    }
}