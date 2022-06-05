using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

public static class ArrayExtension
{
    public static T First<T>(this T[] array)
    {
        return array[0];
    }

    public static T Last<T>(this T[] array)
    {
        return (array[array.Length - 1]);
    }

    public static T First<T>(this List<T> array)
    {
        return array[0];
    }

    public static T Last<T>(this List<T> array)
    {
        return (array[array.Count - 1]);
    }

    public static T GetRandomElement<T>(this T[] array)
    {
        Random random = new Random();
        return array[random.Next(0, array.Length)];
    }

    public static T GetRandomElement<T>(this List<T> list)
    {
        Random random = new Random();
        return list[random.Next(0, list.Count)];
    }

    public static int IndexOf<T>(this List<T> list, Func<T, bool> selector)
    {
        if (list != null)
        {
            int i = 0;
            while (i < list.Count)
            {
                if (selector(list[i]))
                {
                    return i;
                }
                i++;
            }
        }
        return -1;
    }

    public static string ToString<T>(this List<T> list)
    {
        StringBuilder sb = new StringBuilder("Count: ").Append(list.Count).Append(", Elements: ");
        foreach (T item in list)
        {
            sb.Append('[').Append(item).Append("] ");
        }
        return sb.ToString();
    }

    //public static bool Contains<T>(this IEnumerable<T> enumerable, T element)
    //{
    //    if(enumerable == null || element == null)
    //        return false;

    //    foreach (var item in enumerable)
    //    {
    //        if (element.Equals(item))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
}