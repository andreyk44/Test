using System.Collections.Generic;
using System.Linq;

namespace Kiuss.Domain.Shared.Model
{
  public static class ValueCollectionExtension
  {
    public static bool EquivalentValuesTo<TValue>(this IEnumerable<TValue> source, IEnumerable<TValue> target)
      where TValue : ValueObject
    {
      if (source == null || target == null)
        return (source == null && target == null);

      var sourceArray = source as TValue[] ?? source.ToArray();
      var targetArray = target as TValue[] ?? target.ToArray();

      if (sourceArray.Length != targetArray.Length)
        return false;

      if (sourceArray.Except(targetArray).Any())
        return false;

      if (targetArray.Except(sourceArray).Any())
        return false;

      return true;
    }

    public static void SyncValues<TValue>(this IList<TValue> source, IList<TValue> target)
      where TValue: ValueObject
    {
      if (source == null || target == null)
        return;

      var added = target.Except(source).ToArray();
      var deleted = source.Except(target).ToArray();

      foreach (var d in deleted)
      {
        source.Remove(d);
      }

      foreach (var a in added)
      {
        source.Add(a);
      }
    }

    public static IList<TValue> GetValuesCopy<TValue>(this IList<TValue> source)
      where TValue : ValueObject
    {
      return source.Select(e => e).ToList();
    }



  }
}
