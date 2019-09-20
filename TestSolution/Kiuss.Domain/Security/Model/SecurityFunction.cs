using System;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecurityFunction : SecurityObject
  {
    private SecurityFunction(Guid id) : base(id) { }

    public SecuritySection SecuritySection { get; private set; }
    public Guid SecuritySectionId { get; private set; }

    public KiussFunction Function { get; private set; }
    public Guid FunctionId { get; set; }

    public static SecurityFunction New(KiussFunction function) => new SecurityFunction(Guid.NewGuid())
    {
      Type = SecurityObjectType.Function,
      Function = function,
      FunctionId = function.Id,
    };
  }
}
