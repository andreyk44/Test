using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Security.Model
{
  public class KiussUser : EntityBase<Guid>
  {
    private KiussUser(Guid id) : base(id) { }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    /// <remarks>
    /// Имя пользователя не явлется его именем для входа в систему.
    /// Зарегистрированные учетные записи находятся в коллекции Logins.
    /// </remarks>
    public string Name { get; private set; }

    /// <summary>
    /// Признак активности пользователя.
    /// </summary>
    /// <remarks>
    /// Если пользователь не активен, он не может войти ни в один модуль.
    /// </remarks>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Код культуры для локализации.
    /// </summary>
    public string CultureCode { get; private set; }

    public string LanguageCode => CultureCode?.Split('-').FirstOrDefault();

    /// <summary>
    /// Флаги пользователя.
    /// </summary>
    public KiussUserFeature Features { get; private set; }

    /// <summary>
    /// Коллекция объектов AccessRight предстаялет ассоциацию по типу N:N с объектами SecuritySubject.
    /// </summary>
    public IList<AccessRight> AccessRights { get; private set; }

    /// <summary>
    /// Коллекция владемых объектов KiussLogin предстаялет зарегистрированные учетные записи пользователя.
    /// </summary>
    public IList<KiussLogin> Logins { get; private set; }

    public IEnumerable<SecurityRole> Roles =>
     AccessRights.Where(e => e.SecuritySubject.Type == SecuritySubjectType.Role).Select(e => (SecurityRole)e.SecuritySubject);

    public IEnumerable<SecurityGroup> Groups =>
     AccessRights.Where(e => e.SecuritySubject.Type == SecuritySubjectType.Group).Select(e => (SecurityGroup)e.SecuritySubject);

    public static KiussUser New(Guid id, string name, string cultureCode, IList<KiussLogin> logins, KiussUserFeature features)
      => new KiussUser(id)
      {
        Name = name,
        IsActive = true,
        CultureCode = cultureCode,
        Features = features,
        Logins = logins,
        AccessRights = new List<AccessRight>()
      };

    public static KiussUser New(Guid id, string name, string cultureCode, KiussUserFeature features)
      => new KiussUser(id)
      {
        Name = name,
        IsActive = true,
        CultureCode = cultureCode,
        Features = features,
        Logins = new List<KiussLogin>(),
        AccessRights = new List<AccessRight>()
      };

    public KiussUser AddSecuritySubject(SecuritySubject securitySubject)
    {
      if (AccessRights == null)
        AccessRights = new List<AccessRight>();
      AccessRights.Add(AccessRight.New(this, securitySubject, DateTimeRange.New()));
      return this;
    }

    public override string ToString()
    {
      return $"{Name}({string.Join(',', AccessRights.Select(ar => ar.SecuritySubject.ToString()))})";
    }

  }
}
