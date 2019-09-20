using System;
using System.Collections.Generic;

namespace Kiuss.Domain.Security.Interfaces
{
  public interface IUserImport
  {
    IList<IKiussUser> KiussUser { get; }
  }

  public interface IKiussUser
  {
    Guid Id { get; }
    string Name { get; }
    string CultureCode { get; }
    string Features { get; }
    IList<IKiussLogin> KiussLogins { get; }
    IList<string> Groups { get; }
    IList<string> Roles { get; }
  }

  public interface IKiussLogin
  {
    string DomainName { get; }
    string LoginName { get; }
    bool IsActive { get; }
    IDateTimeRange Period { get; }
  }

  public interface IDateTimeRange
  {
    DateTime Start { get; }
    DateTime End { get; }
  }
}


