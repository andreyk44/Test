using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.System.Model
{
  public class KiussFunction : EntityBase<Guid>
  {
    private KiussFunction(Guid id) : base(id) { }

    /// <summary>
    /// Раздел, которому принадлежит данная функция.
    /// </summary>
    public KiussSection Section { get; private set; }
    /// <summary>
    /// Идентификатор раздела, которому принадлежит данная функция.
    /// </summary>
    public Guid SectionId { get; private set; }

    /// <summary>
    /// Тип функции.
    /// </summary>
    public FunctionType Type { get; private set; }

    public static KiussFunction New(Guid id, KiussSection section, FunctionType type)
     => new KiussFunction(id)
     {
       Section = section,
       SectionId = section.Id,
       Type = type
     };

    public static KiussFunction Confirm() => new KiussFunction(Guid.NewGuid())
    {
      Type = FunctionType.ConfirmSection,
    };
    public static KiussFunction Unconfirm() => new KiussFunction(Guid.NewGuid())
    {
      Type = FunctionType.UnconfirmSection,
    };

    public static KiussFunction Approve() => new KiussFunction(Guid.NewGuid())
    {
      Type = FunctionType.ApproveSection,
    };
    public static KiussFunction Unapprove() => new KiussFunction(Guid.NewGuid())
    {
      Type = FunctionType.UnapproveSection,
    };

    public static KiussFunction ConfirmAndApprove() => new KiussFunction(Guid.NewGuid())
    {
      Type = FunctionType.ConfirmApproveSection,
    };
    public static KiussFunction UnapproveUnconfirmSection() => new KiussFunction(Guid.NewGuid())
    {
      Type = FunctionType.UnapproveUnconfirmSection,
    };

    public static IEnumerable<KiussFunction> StandardSet() => new[]
    {
      Confirm(), Unconfirm(), Approve(), Unapprove(), ConfirmAndApprove(), UnapproveUnconfirmSection()
    };
  }
}
