using System;
using System.Collections.Generic;

namespace Kiuss.Domain.System.Interfaces
{
  public interface IModuleImport
  {
    IList<IKiussModule> KiussModules { get; }
  }

  public interface IKiussSection
  {
    int Position { get; }
    Guid Id { get; }
    string Name { get; }
    string Type { get; }
    string Description { get; }
    bool Active { get; }
    IList<IKiussFunction> Functions { get; }
  }

  public interface ISection
  {
    string Name { get; }
    string Type { get; }
    IList<IFunctions> Functions { get; }

  }
  public interface IFunctions
  {
    Guid Id { get; }
    string Type { get; }
  }
  public interface IKiussModule
  {
    Guid Id { get; }
    string SystemName { get; }
    string Name { get; }
    string Type { get; }
    IList<IKiussSection> KiussSections { get; }
  }

  public interface IKiussFunction
  {
    Guid Id { get; }
    string Type { get; }
  }
}
