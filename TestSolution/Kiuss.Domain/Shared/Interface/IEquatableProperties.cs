using System;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Shared.Interface
{
  public interface IEquatableProperties<TEntity> : IEquatableProperties<TEntity, Guid> where TEntity: EntityBase<Guid>
  {
  }


  /// <summary>
  /// Интерфейс, который реализуют классы доменной модели для того, чтобы использоваться в EntitySet<> и EntitySetChange<>.
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IEquatableProperties<TEntity, out TKey> where TEntity : EntityBase<TKey>
  {
    /// <summary>
    /// Доступ к идентификатору сущности.
    /// </summary>
    TKey Id { get; }

    /// <summary>
    /// Проверяет объект на равенство значений всех свойств с другим объектом.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>True, если все свойства имеют одинаковые значения</returns>
    bool PropertiesEqual(TEntity other);

    /// <summary>
    /// Синхронизирует все свойства объекта со свойствами указанного объекта.
    /// </summary>
    /// <param name="other"></param>
    void SyncProperties(TEntity other);

    /// <summary>
    /// Возвращает объект, все свойства которого являются копиями свойств данного объекта.
    /// </summary>
    /// <returns>Полная копия объекта</returns>
    TEntity GetCopy();
  }

}
