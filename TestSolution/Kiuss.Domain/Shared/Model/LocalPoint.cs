using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{
  [Owned]
  public class LocalPoint : ValueObject
  {
    private LocalPoint() { }

    public static LocalPoint New(decimal x, decimal y) => new LocalPoint()
    {
      X = x,
      Y = y
    };
    public static LocalPoint Empty() => new LocalPoint()
    {
      X = null,
      Y = null
    };


    public decimal? X { get; private set; }
    public decimal? Y { get; private set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return X;
      yield return Y;
    }

    public override string ToString()
    {
      return $"{X} x {Y}";
    }
  }
}
