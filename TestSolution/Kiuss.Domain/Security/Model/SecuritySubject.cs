using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecuritySubject : EntityBase<string>
  {
    protected SecuritySubject(string id): base(id) { }
    public SecuritySubjectType Type { get; protected set; }

    public static SecuritySubject New(string id, SecuritySubjectType type)
      => new SecuritySubject(id)
      {
        Type = type
      };

    public override string ToString()
    {
      return $"{Type}({Id})";
    }
  }
}
