using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{
  /// <summary>
  /// Временной диапазон.
  /// </summary>
  [Owned]
  public class DateTimeRange : ValueObject
  {
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    private DateTimeRange(DateTime start, DateTime end)
    {
      Start = start;
      End = end;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Start;
      yield return End;
    }

    public override string ToString()
    {
      return $"[{Start};{End}]";
    }

    /// <summary>
    /// Возвращает новый временной дапазон с указанными границами.
    /// </summary>
    /// <param name="start">Начало диапазона. Null означает открытую границу.</param>
    /// <param name="end">Конец диапазона. Null означает открытую границу.</param>
    /// <returns>Новый временной диапазон.</returns>
    public static DateTimeRange New(DateTime? start, DateTime? end)
      => new DateTimeRange(start ?? DateTime.MinValue, end ?? DateTime.MaxValue);

    /// <summary>
    /// Возвращает новый временной дапазон с указанными границами.
    /// </summary>
    /// <param name="start">Начало диапазона. Null означает открытую границу.</param>
    /// <param name="end">Конец диапазона. Null означает открытую границу.</param>
    /// <returns>Новый временной диапазон.</returns>
    public static DateTimeRange New(string start, string end)
    {
      return New(string.IsNullOrWhiteSpace(start) ? (DateTime?)null : DateTime.Parse(start), 
                 string.IsNullOrWhiteSpace(end) ? (DateTime?)null : DateTime.Parse(end));
    }

    /// <summary>
    /// Возвращает новый временной дапазон с открытыми границами.
    /// </summary>
    /// <returns>Новый временной диапазон.</returns>
    public static DateTimeRange New() => New(null, (DateTime?)null);


    public bool Contains(DateTime dt) => dt >= Start && dt <= End;
  }
}
