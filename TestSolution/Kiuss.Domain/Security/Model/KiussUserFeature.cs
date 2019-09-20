using System;

namespace Kiuss.Domain.Security.Model
{
  [Flags]
  public enum KiussUserFeature
  {
    Default = 0,
    System = 1,
    Guest = 2,
    Remote = 4
  }
}