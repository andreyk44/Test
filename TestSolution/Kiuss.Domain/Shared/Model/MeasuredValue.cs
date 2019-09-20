using System.Collections.Generic;
using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  public class MeasuredValue<T> : ValueObject, IMeasurable
  {
    public T Amount { get; protected set; }
    public UnitOfMeasure UOM { get; protected set; }

    protected MeasuredValue() { }
    protected MeasuredValue(T amount, UnitOfMeasure uom)
    {
      Amount = amount;
      UOM = uom;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Amount;
      yield return UOM;
    }

    public override string ToString() =>
      ((Amount?.ToString() ?? string.Empty) + " " + (UOM?.ToString() ?? string.Empty)).Trim();


    public void Replace(MeasuredValue<T> other)
    {
      Amount = other.Amount;
      UOM = UnitOfMeasure.New(other.UOM.Code);
    }


  }
}