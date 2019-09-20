using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{
  [Owned]
  public class GeoCoord : ValueObject
  {
    private GeoCoord() { }

    public short? Degrees { get; private set; }

    public short? Minutes { get; private set; }

    public decimal? Seconds { get; private set; }


    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Degrees;
      yield return Minutes;
      yield return Seconds;
    }

    public static GeoCoord New(short? degrees, short? minutes, decimal? seconds) => new GeoCoord()
    {
      Degrees = degrees,
      Minutes = minutes,
      Seconds = seconds
    };

    public static GeoCoord Empty() => new GeoCoord()
    {
      Degrees = null,
      Minutes = null,
      Seconds = null
    };


    public override string ToString()
    {
      return $"{Degrees}°{Minutes}'{Seconds}''";
    }

    public bool IsValidLatitude() => Degrees >= -90 && Degrees <= 90 &&
                                     Minutes >= 0 && Minutes < 60 &&
                                     Seconds >= decimal.Zero && Seconds < 60M;

    public bool IsValidLongitude() => Degrees >= -180 && Degrees <= 180 &&
                                      Minutes >= 0 && Minutes < 60 &&
                                      Seconds >= decimal.Zero && Seconds < 60M;
  }
}