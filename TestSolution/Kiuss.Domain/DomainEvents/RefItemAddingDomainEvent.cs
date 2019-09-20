using Kiuss.Domain.Shared.Interface;
using Kiuss.Domain.Shared.Model;
using MediatR;

namespace Kiuss.Domain.DomainEvents
{
  /// <summary>
  /// Доменное событие, описывающее добавление элемента в справочник.
  /// </summary>
  public class RefItemAddingDomainEvent : ITransactionalNotification
  {
    public RefBase RefItem { get; private set; }

    private RefItemAddingDomainEvent() { }

    public static INotification New(RefBase refItem) => new RefItemAddingDomainEvent()
    {
      RefItem = refItem
    };
  }
}
