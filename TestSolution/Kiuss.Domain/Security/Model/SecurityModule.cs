using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecurityModule : SecurityObject
  {
    private SecurityModule(Guid id) : base(id) { }

    public KiussModule Module { get; private set; }
    public Guid ModuleId { get; private set; }

    public IList<SecuritySection> SecuritySections { get; set; }

    public static SecurityModule New(KiussModule module)
      => new SecurityModule(Guid.NewGuid())
      {
        Type = SecurityObjectType.Module,
        Module = module,
        ModuleId = module.Id,
        SecuritySections = module.Sections.Select(SecuritySection.New).ToList()
      };

    public IList<SecuritySection> Sections()
    {
      return SecuritySections;
    }

    public SecuritySection Section(Guid sectionId)
    {
      return SecuritySections.FirstOrDefault(securitySection => securitySection.SectionId == sectionId);
    }


    public SecurityFunction Function(Guid sectionId, FunctionType functionType)
    {
      return SecuritySections.FirstOrDefault(securitySection => securitySection.SectionId == sectionId)?.Function(functionType);
    }

  }
}