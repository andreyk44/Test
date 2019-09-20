using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  public class EntitySetChange<TEntity> : EntitySetChange<TEntity, Guid> where TEntity : EntityBase<Guid>, IEquatableProperties<TEntity>
  {
    protected EntitySetChange(EntitySet<TEntity, Guid> oldSet, EntitySet<TEntity, Guid> newSet) : base(oldSet, newSet) { }

    public static EntitySetChange<TEntity> New(EntitySet<TEntity> oldSet, EntitySet<TEntity> newSet)
      => new EntitySetChange<TEntity>(oldSet, newSet);

  }

  public class EntitySetChange<TEntity, TKey> where TEntity : EntityBase<TKey>, IEquatableProperties<TEntity, TKey>
  {
    private readonly EntitySet<TEntity, TKey> _oldSet;
    private readonly EntitySet<TEntity, TKey> _newSet;

    protected EntitySetChange(EntitySet<TEntity, TKey> oldSet, EntitySet<TEntity, TKey> newSet)
    {
      _oldSet = oldSet;
      _newSet = newSet;
    }

    public static EntitySetChange<TEntity, TKey> New(EntitySet<TEntity, TKey> oldSet, EntitySet<TEntity, TKey> newSet)
      => new EntitySetChange<TEntity, TKey>(oldSet, newSet);

    public bool Any() => Added.Any() || Updated.Any() || Deleted.Any();

    private IDictionary<TKey, int> _newSequence;
    public IDictionary<TKey, int> NewSequence => _newSequence
                                                 ?? (_newSequence = new Dictionary<TKey, int>(_newSet.Entities.Select((op, ind) => new KeyValuePair<TKey, int>(op.Id, ind))));

    private IList<TEntity> _added;
    public IList<TEntity> Added => _added
                                   ?? (_added = _newSet.Entities.Where(opNew => _oldSet.Entities.All(op => !op.Equals(opNew))).ToList());

    private IList<(TEntity Old, TEntity New)> _updated;
    public IList<(TEntity Old, TEntity New)> Updated => _updated
                                                        ?? (_updated = (from old in _oldSet.Entities
                                                          join @new in _newSet.Entities on old equals @new
                                                          where !old.PropertiesEqual(@new)
                                                          select (old, @new)).ToList());
    private IList<TEntity> _deleted;
    public IList<TEntity> Deleted => _deleted
                                     ?? (_deleted = _oldSet.Entities.Where(op => !_newSet.Entities.Contains(op)).ToList());

  }

}
