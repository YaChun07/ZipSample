using System.Collections.Generic;

namespace ZipSample.test
{
    public static class MyLinq
    {
        public static IEnumerable<T> MyConcat<T>(this IEnumerable<T> first, IEnumerable<T> second)
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