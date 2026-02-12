using System;
using System.Collections;

namespace Wang.Seamas.Queryable.Extensions;

public static class EnumerableExtensions
{
    public static bool AnyElements(this IEnumerable? source)
    {
        if (source == null)
        {
            return false;
        }
        var enumerator = source.GetEnumerator();
        using (enumerator as IDisposable)
        {
            return enumerator.MoveNext();
        }
        
    }
}