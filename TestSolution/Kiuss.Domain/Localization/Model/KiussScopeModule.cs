using System;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.Localization.Model
{
  public class KiussScopeModule : KiussScope
  {
    public KiussModule Module { get; private set; }
    public Guid ModuleId { get; private set; }

    public override Guid ScopeId => ModuleId;

    public static KiussScopeModule New(KiussModule module)
    {
      return new KiussScopeModule()
      {
        Type = KiussScopeType.Module,
        Module = module,
        ModuleId = module.Id
      };
    }

  }
}