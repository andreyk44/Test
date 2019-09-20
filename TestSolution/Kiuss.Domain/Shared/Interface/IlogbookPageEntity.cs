using System;

namespace Kiuss.Domain.Shared.Interface
{
  public interface ILogbookPageEntity : ILogbookPageEntity<Guid>
  {
  }

  public interface ILogbookPageEntity<out TKey>
  {
    Guid PageId { get; }
    TKey EntityId { get; }
    void SetPosition(int position);
  }

}
