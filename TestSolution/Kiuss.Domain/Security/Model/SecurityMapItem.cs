using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecurityMapItem : ValueObject
  {
    private SecurityMapItem() { }

    public Guid SecurityObjectId { get; private set; }
    public SecurityObject SecurityObject { get; private set; }

    public string SecuritySubjectId { get; private set; }
    public SecuritySubject SecuritySubject { get; private set; }

    public AccessLevel AccessLevel { get; private set; }

    /// <summary>
    /// Создает объект доступа с укзанным типом.
    /// </summary>
    /// <param name="securityObject">Объект доступа</param>
    /// <param name="securitySubject">Субъект доступа</param>
    /// <param name="accessLevel">Тип доступа</param>
    /// <returns>Объект доступа</returns>
    public static SecurityMapItem New(SecurityObject securityObject, SecuritySubject securitySubject, AccessLevel accessLevel)
    {
      return new SecurityMapItem()
      {
        SecurityObject = securityObject,
        SecurityObjectId = securityObject.Id,
        SecuritySubject = securitySubject,
        SecuritySubjectId = securitySubject.Id,
        AccessLevel = accessLevel
      };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return SecurityObjectId;
      yield return SecuritySubjectId;
      yield return AccessLevel;
    }
  }
}