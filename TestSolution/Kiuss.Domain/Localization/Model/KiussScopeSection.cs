using System;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.Localization.Model
{
  public class KiussScopeSection : KiussScope
  {
    public KiussSection Section { get; private set; }
    public Guid SectionId { get; private set; }

    public override Guid ScopeId => SectionId;

    public static KiussScopeSection New(KiussSection section)
    {
      return new KiussScopeSection()
      {
        Type = KiussScopeType.Section,
        Section = section,
        SectionId = section.Id
      };
    }
  }
}