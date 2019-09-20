using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  public static class EntityCollectionExtension
  {
    public static bool EquivalentEntitiesTo<TEntity>(this IEnumerable<TEntity> source, IEnumerable<TEntity> target)
      where TEntity : EntityBase<Guid>, IEquatableProperties<TEntity>
    {
      if (source == null || target == null)
        return (source == null && target == null);

      var sourceArray = source as TEntity[] ?? source.ToArray();
      var targetArray = target as TEntity[] ?? target.ToArray();

      if (sourceArray.Length != targetArray.Length)
        return false;

      var comparer = new EntityPropertyComparer<TEntity>();
      if (sourceArray.Except(targetArray, comparer).Any())
        return false;

      if (targetArray.Except(sourceArray, comparer).Any())
        return false;

      return true;
    }

    public static void SyncEntities<TEntity>(this IList<TEntity> source, IList<TEntity> target)
      where TEntity : EntityBase<Guid>, IEquatableProperties<TEntity>
    {
      if (source == null || target == null)
        return;

      var added = target.Except(source).ToArray();
      var deleted = source.Except(target).ToArray();

      foreach (var d in deleted)
      {
        source.Remove(d);
      }

      foreach (var entitySource in source)
      {
        var entityTarget = target.FirstOrDefault(e => e.Id == entitySource.Id);
        if (entityTarget == null)
          continue;
        if (!entitySource.PropertiesEqual(entityTarget))
          entitySource.SyncProperties(entityTarget);
      }

      foreach (var a in added)
      {
        source.Add(a);
      }
    }


    public static IList<TEntity> GetEntitiesCopy<TEntity>(this IList<TEntity> source)
      where TEntity : EntityBase<Guid>, IEquatableProperties<TEntity>
    {
      return source.Select(e => e.GetCopy()).ToList();
    }

    public static TEntity GetEntityCopy<TEntity>(this TEntity source)
      where TEntity : EntityBase<Guid>, IEquatableProperties<TEntity>
    {
      return source.GetCopy();
    }


    private class EntityPropertyComparer<TEntity> : EqualityComparer<TEntity>
      where TEntity : EntityBase<Guid>, IEquatableProperties<TEntity>
    {
      public override int GetHashCode(TEntity obj)
      {
        return obj.Id.GetHashCode();
      }

      public override bool Equals(TEntity x, TEntity y)
      {
        return x.Id == y.Id && x.PropertiesEqual(y);
      }
    }

  }
}