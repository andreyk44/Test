using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecuritySection : SecurityObject
  {
    private SecuritySection(Guid id) : base(id) { }

    public SecurityModule SecurityModule { get; private set; }
    public Guid SecurityModuleId { get; private set; }

    public KiussSection Section { get; private set; }
    public Guid SectionId { get; private set; }

    public IList<SecurityFunction> SecurityFunctions { get; set; }

    
    public static SecuritySection New(KiussSection section) => new SecuritySection(Guid.NewGuid())
    {
      Type = SecurityObjectType.Section,
      Section = section,
      SectionId = section.Id,
      SecurityFunctions = section.Functions.Select(SecurityFunction.New).ToList()
    };

    public SecurityFunction Function(FunctionType functionType)
    {
      return SecurityFunctions.FirstOrDefault(sf => sf.Function.Type == functionType);
    }
  }
}
