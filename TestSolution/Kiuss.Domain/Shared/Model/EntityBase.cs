using System;

namespace Kiuss.Domain.Shared.Model
{
  public abstract class EntityBase<TIdType> :  IEquatable<EntityBase<TIdType>>
  {
    public TIdType Id { get; protected set; }

    protected EntityBase() : this(default) { }
    protected EntityBase(TIdType id) => Id = id;

    public bool Equals(EntityBase<TIdType> other) => other != null && Id.Equals(other.Id);

    #region Equals
    public override bool Equals(object entity)
    {
      return entity is EntityBase<TIdType> @base && this == @base;
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public static bool operator ==(EntityBase<TIdType> entity1, EntityBase<TIdType> entity2)
    {
      if ((object)entity1 == null && (object)entity2 == null)
      {
        return true;
      }

      if ((object)entity1 == null || (object)entity2 == null)
      {
        return false;
      }

      return entity1.Id.ToString() == entity2.Id.ToString();
    }

    public static bool operator !=(EntityBase<TIdType> entity1, EntityBase<TIdType> entity2)
    {
      return (!(entity1 == entity2));
    }

    #endregion

  }


  
}
