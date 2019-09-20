using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{
  /// <summary>
  /// Диапазон значений количесва.
  /// </summary>
  [Owned]
  public class AmountRange : ValueObject
  {
    public decimal? Start { get; private set; }
    public decimal? End { get; private set; }

    private AmountRange(decimal? start, decimal? end)
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
      return $"[{Start}:{End}]";
    }

    /// <summary>
    /// Возвращает новый дапазон с указанными границами.
    /// </summary>
    /// <param name="start">Начало диапазона. Null означает открытую границу.</param>
    /// <param name="end">Конец диапазона. Null означает открытую границу.</param>
    /// <returns>Новый диапазон.</returns>
    public static AmountRange New(decimal? start, decimal? end) => new AmountRange(start, end);


    /// <summary>
    /// Провереят вхождение указанного количества в диапазон.
    /// </summary>
    /// <param name="amount">Проверяемое количество</param>
    /// <returns></returns>
    public bool InRange(decimal amount) => Start is null || amount >= Start && End is null || amount <= End;

    /// <summary>
    /// Возвращает пустой дапазон.
    /// </summary>
    /// <returns></returns>
    public static AmountRange Empty() => new AmountRange(null, null);
  }
}
