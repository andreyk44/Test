using System;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Structure.Model
{
  /// <summary>
  /// Технологический объект бурения.
  /// </summary>
  public class DrillingFacility : EntityBase<Guid>
  {
    public DrillingFacility(Guid id) : base(id) { }

    /// <summary>
    /// Название технологического объекта.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Адрес сервиса интеграции данных.
    /// </summary>
    public string IntegrationEndPoint { get; private set; }
  }
}