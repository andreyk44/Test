using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{

  [Owned]
  public class Quantity : MeasuredValue<decimal?>
  {
    public static (int Precision, int Scale) Standard = (12, 3);
    public static (int Precision, int Scale) Integer = (9, 0);

    private Quantity() { }

    public static Quantity New(decimal? amount, UnitOfMeasure uom) => new Quantity()
    {
      Amount = amount,
      UOM = uom
    };
    public static Quantity Default(UnitOfMeasure uom) => New(null, uom);

    public override string ToString()
    {
      return (Amount?.ToString($"N{Standard.Scale}", CultureInfo.InvariantCulture) ?? string.Empty)
           + (Amount is null ? string.Empty : (UOM is null ? string.Empty : " "))
           + (UOM?.ToString() ?? string.Empty);
    }

    public int? ToInt32() => Amount is null ? (int?)null : Convert.ToInt32(Amount);
    public decimal? ToDecimal() => Amount;

  }
}
