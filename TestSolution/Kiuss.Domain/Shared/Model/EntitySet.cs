using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  public class EntitySet<TEntity> : EntitySet<TEntity, Guid> where TEntity : EntityBase<Guid>, IEquatableProperties<TEntity>
  {
    protected EntitySet(IList<TEntity> entities) : base(entities) { }

    public new static EntitySet<TEntity> New(IList<TEntity> entities) => new EntitySet<TEntity>(entities);
    public new static EntitySet<TEntity> New(TEntity entity) => new EntitySet<TEntity>(entity == null ? new List<TEntity>() : new List <TEntity> { entity });
    public EntitySetChange<TEntity> GetChange(EntitySet<TEntity> other) => EntitySetChange<TEntity>.New(this, other);
  }


  public class EntitySet<TEntity, TKey> where TEntity : EntityBase<TKey>, IEquatableProperties<TEntity, TKey>
  {
    private readonly IList<TEntity> _entities;

    protected EntitySet(IList<TEntity> entities) => _entities = entities;

    public IReadOnlyList<TEntity> Entities => _entities.ToImmutableList();
    public IReadOnlyList<TKey> EntityKeys => _entities.Select(e => e.Id).ToImmutableList();

    public static EntitySet<TEntity, TKey> New(IList<TEntity> entities) => new EntitySet<TEntity, TKey>(entities);
    public static EntitySet<TEntity, TKey> New(TEntity entity) => new EntitySet<TEntity, TKey>(entity == null ? new List<TEntity>() : new List<TEntity> { entity });

    public bool IsEmpty() => !_entities.Any();

    public EntitySetChange<TEntity, TKey> GetChange(EntitySet<TEntity, TKey> other) => EntitySetChange<TEntity, TKey>.New(this, other);

  }


}
