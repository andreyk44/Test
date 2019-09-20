using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Shared.Interface
{
  public interface IMeasurable
  {
    UnitOfMeasure UOM { get; }
  }
}
