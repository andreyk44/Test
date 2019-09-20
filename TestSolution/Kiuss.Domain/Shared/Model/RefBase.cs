using System;
using Kiuss.Domain.DomainEvents;
using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  /// <summary>
  /// Базовый класс справочников.
  /// </summary>
  public abstract class RefBase : EntityBase<Guid>, IDomainEvent
  {
    protected RefBase(Guid id) : base(id) { }

    private IDomainEventHolder _domainEventHolder;
    public IDomainEventHolder EventHolder => _domainEventHolder ?? (_domainEventHolder = new DomainEventHolder());

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Зарегистрировать заявку на создание нового элемента справочника, в качестве которого выступает сам объект.
    /// </summary>
    public void RegisterItemAdding()
    {
      EventHolder.Add(RefItemAddingDomainEvent.New(this));
    }

  }
}
