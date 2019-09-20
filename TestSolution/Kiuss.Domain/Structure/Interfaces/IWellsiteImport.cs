using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Structure.Interfaces
{
  public interface IWellsiteImport
  {
    OilfieldType Type { get; }
    IList<IWellsite> Wellsites { get; }
  }

  public interface IWellsite
  {
    Guid Id { get; }
    string Name { get; }
    IAdminister Administer { get; }
    IList<IContractor> Contractors { get; }
  }

  public interface IAdminister
  {
    string Name { get; }
    IPeriod Period { get; }
  }

  public interface IContractor
  {
    string Line { get; }
    string Name { get; }
    IPeriod Period { get; }
  }

  public interface IPeriod
  {
    string From { get; }
    string To { get; }
  }

}