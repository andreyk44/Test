using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{
  [Owned]
  public class GeoPoint : ValueObject
  {
    private GeoPoint() { }

    public static GeoPoint New(GeoCoord latitude, GeoCoord longitude)
    {
      return new GeoPoint()
      {
        Latitude = latitude,
        Longitude = longitude
      };
    }

    public GeoCoord Latitude { get; private set; }
    public GeoCoord Longitude { get; private set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Latitude;
      yield return Longitude;
    }

    public override string ToString()
    {
      return $"{Latitude} x {Longitude}";
    }
  }
}
