using System;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Security.Model
{
  /// <summary>
  /// Ассоциация пользователя с ролью или группой доступа.
  /// </summary>
  public class AccessRight
  {
    private AccessRight() { }

    public Guid UserId { get; private set; }
    public KiussUser User { get; private set; }

    public string SecuritySubjectId { get; private set; }
    public SecuritySubject SecuritySubject { get; private set; }

    /// <summary>
    /// Период времени, в течении которого данная ассоциация действительна.
    /// </summary>
    public DateTimeRange Period { get; private set; }

    /// <summary>
    /// Признак активности ассоциации.
    /// </summary>
    /// <remarks>
    /// Если ассоциация не активна, она не может быть использована
    /// для доступа к соотвествующему объекту безопасности.
    /// </remarks>
    public bool IsActive { get; private set; }


    public static AccessRight New (KiussUser user, SecuritySubject securitySubject, DateTimeRange period)
    {
      return new AccessRight()
      {
        User = user,
        SecuritySubject = securitySubject,
        Period = period
      };
    }
  }

}

