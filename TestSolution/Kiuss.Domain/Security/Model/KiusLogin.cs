using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Security.Model
{
  /// <summary>
  /// Учетная запись пользователя.
  /// </summary>
  public class KiussLogin : ValueObject
  {
    private KiussLogin() { }
    public string DomainName { get; private set; }

    public string LoginName { get; private set; }

    /// <summary>
    /// Признак активности учетной записи.
    /// </summary>
    /// <remarks>
    /// Если учетная запись не активна, она не может быть использована для входа ни в один модуль.
    /// </remarks>
    public bool IsActive { get; private set; }
    public DateTimeRange Period { get; set; }
    public static KiussLogin New(string domainName, string loginName, bool isActive, DateTimeRange period)
     => new KiussLogin()
     {
       DomainName = domainName,
       LoginName = loginName,
       IsActive = isActive,
       Period = period
     };

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return DomainName;
      yield return LoginName;
      yield return IsActive;
      yield return Period;
    }
  }
}
