using System;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.KiussEvents.Model
{
  /// <summary>
  /// Событие КиУСС.
  /// </summary>
  public class KiussEvent : EntityBase<Guid>
  {
    protected KiussEvent(Guid id) : base(id) { }

    /// <summary>
    /// Дата/время возникновения события.
    /// </summary>
    public DateTime Issued { get; protected set; }

    /// <summary>
    /// Модуль КиУСС, к которому относится событие.
    /// </summary>
    public KiussModule KiussModule { get; protected set; }
    public Guid? KiussModuleId { get; protected set; }


    /// <summary>
    /// Раздел модуля, к которому относится событие.
    /// </summary>
    public KiussSection KiussSection { get; protected set; }
    public Guid? KiussSectionId { get; protected set; }

    /// <summary>
    /// Тип события.
    /// </summary>
    public KiussEventType Type { get; protected set; }

  }
}
