using System;
using System.Collections;
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

        //stack 在初始化的時候就會做push
        //IEnumerable 拿的時候會以pop形式拿
        //IEnumerable<T> 強型別
        //IEnumerable 弱型別
        public static IEnumerable<T> MyReverse<T>(this IEnumerable<T> source)
        {
            return new Stack<T>(source);
        }

        public static IEnumerable<TResult> MyOfType<TResult>(this IEnumerable source)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is TResult)
                {
                    yield return (TResult)enumerator.Current;
                }
            }
        }

        public class AmandaException : Exception
        {
        }

        public static IEnumerable<TResult> MyCast<TResult>(this IEnumerable arrayList)
        {
            var enumerator = arrayList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is TResult)
                {
                    yield return (TResult)enumerator.Current;
                }
                else
                {
                    throw new AmandaException();
                }
            }
        }

        public static IEnumerable<TResult> MyZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            var girlEmu = first.GetEnumerator();
            var keyEmu = second.GetEnumerator();
            while (keyEmu.MoveNext() && girlEmu.MoveNext())
            {
                var girlEmuCurrent = girlEmu.Current;
                var keyEmuCurrent = keyEmu.Current;
                yield return selector(girlEmuCurrent, keyEmuCurrent);
            }
        }

        public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return MyZip(first, second, EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> MyZip<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> myEqualityCompare)
        {
            var firstEnum = first.GetEnumerator();
            var secondEnum = second.GetEnumerator();

            var hashSet = new HashSet<TSource>(myEqualityCompare);

            while (firstEnum.MoveNext())
            {
                if (hashSet.Add(firstEnum.Current))
                {
                    yield return firstEnum.Current;
                }
            }
            while (secondEnum.MoveNext())
            {
                if (hashSet.Add(secondEnum.Current))
                {
                    yield return secondEnum.Current;
                }
            }
        }
    }
}