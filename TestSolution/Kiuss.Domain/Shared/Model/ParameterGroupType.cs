namespace Kiuss.Domain.Shared.Model
{
  /// <summary>
  /// Тип группировки двух или более параметров внутри некоторой коллекции параметров.
  /// </summary>
  public enum ParameterGroupType
  {
    /// <summary>
    /// Обычная группировка. 
    /// </summary>
    Default = 0,
    /// <summary>
    /// Параметры задают некий интервал. 
    /// </summary>
    Interval = 1,
    /// <summary>
    /// Зависимость между параметрами.
    /// </summary>
    Dependency = 2,
  }
}