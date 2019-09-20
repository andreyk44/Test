using System;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecurityObject : EntityBase<Guid>
  {
    protected SecurityObject(Guid id): base(id) { }
    public SecurityObjectType Type { get; protected set; }
   
    public static SecurityObject New(Guid id, SecurityObjectType type)
      => new SecurityObject(id)
      {
        Type = type
      };

    public override string ToString()
    {
      return $"{Type}({Id})";
    }
  }
}
