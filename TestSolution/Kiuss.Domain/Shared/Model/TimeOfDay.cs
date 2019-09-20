using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{
  [Owned]
  public class TimeOfDay : ValueObject, IComparable<TimeOfDay>
  {
    public int Hour { get; set; }
    public int Minute { get; set; }

    private TimeOfDay() { }

    public static TimeOfDay New(TimeOfDay other) => New(other.Hour, other.Minute);

    public static TimeOfDay New(int hour, int minute) => new TimeOfDay
    {
      Hour = hour,
      Minute = minute
    };

    public static TimeOfDay New(TimeSpan ts) => new TimeOfDay
    {
      Hour = ts.Hours,
      Minute = ts.Minutes
    };

    public static TimeOfDay Zero() => New(0, 0);

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Hour;
      yield return Minute;
    }

    public override string ToString()
    {
      return $"{Hour}:{Minute}";
    }

    public TimeSpan AsTimeSpan() => TimeSpan.FromMinutes(Hour * 60 + Minute);
    public int AsMinutes() => Hour * 60 + Minute;

    int IComparable<TimeOfDay>.CompareTo(TimeOfDay other)
    {
      if (ReferenceEquals(this, other)) return 0;
      if (ReferenceEquals(null, other)) return 1;
      var hourComparison = Hour.CompareTo(other.Hour);
      return hourComparison != 0 ? hourComparison : Minute.CompareTo(other.Minute);
    }

  }
}
