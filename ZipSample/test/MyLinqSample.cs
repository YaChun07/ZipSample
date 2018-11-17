﻿using System;
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
    }
}