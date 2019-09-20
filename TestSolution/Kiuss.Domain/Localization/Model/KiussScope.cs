using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.Localization.Model
{
  public class KiussScope : ValueObject
  {
    public KiussScopeType Type { get; protected set; }
    public virtual Guid ScopeId => Guid.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Type;
      yield return ScopeId;
    }

    public static KiussScope New() => new KiussScope()
    {
      Type = KiussScopeType.Global
    };

    public static KiussScope NewDefault() => New();
    public static KiussScope NewModule(KiussModule module) => KiussScopeModule.New(module);
    public static KiussScope NewSection(KiussSection section) => KiussScopeSection.New(section);

  }
}