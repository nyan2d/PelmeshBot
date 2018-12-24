using System;
using System.Collections.Generic;

namespace PelmeshBot.Extensions
{
    public static class IEnumerableExtenstion
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
