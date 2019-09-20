using System.Collections.Generic;
using Kiuss.Domain.System.Interfaces;

namespace Kiuss.Domain.Security.Interfaces
{
 public interface ISecurityImport
  {
    IList<ISecurityMapGroups> SecurityMapGroups { get; }
    IList<ISecurityMapRole> SecurityMapRoles { get; }
    IList<ISecurityGroup> Groups { get; }
    IList<ISecurityRole> Roles { get; }
  }

  public interface ISecurityMapRole
  {
    string Role { get; }
    IList<IModules> Modules { get; }
  }

  public interface IModules
  {
    string Name { get; }
    string Type { get; }
    IList<ISection> Sections { get; }
  }

  public interface ISecurityMapGroups
  {
    string Group { get; }
    IList<ICompany> Companies { get; }
  }

  public interface ISecurityGroup
  {
    string Id { get; }
  }

  public interface ISecurityRole
  {
    string Id { get; }
    string Name { get; }
  }

  public interface ICompany
  {
    string Name { get; }
  }

}
