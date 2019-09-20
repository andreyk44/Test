using System;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Structure.Model.AccountabilityAggregate
{
  /// <summary>
  /// Представляет отношение подотчетности между двумя сторонами.
  /// </summary>
  public class Accountability : EntityBase<Guid>
  {
    protected Accountability(Guid id) : base(id) { }

    /// <summary>
    /// Тип отношения подотчетности.
    /// </summary>
    /// <remarks>
    /// Contractual, Administer,..
    /// </remarks>
    public AccountabilityType AccountabilityType { get; protected set; }

    /// <summary>
    /// Уполномоченная сторона.
    /// </summary>
    public AccountabilityParty Commisioner { get; protected set; }

    /// <summary>
    /// Идентификатор уполномоченной стороны.
    /// </summary>
    public Guid CommisionerId { get; protected set; }

    /// <summary>
    /// Ответственная сторона.
    /// </summary>
    public AccountabilityParty Responsible { get; protected set; }

    /// <summary>
    /// Идентификатор отвественной стороны.
    /// </summary>
    public Guid ResponsibleId { get; protected set; }

    /// <summary>
    /// Период действия отношения подотчетности.
    /// </summary>
    public DateTimeRange Period { get; set; }

  }
}
