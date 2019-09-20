using System;

namespace Kiuss.Domain.Shared.Model
{
  [Flags]
  public enum UomFeature
  {
    Undefined = 0,

    /// <summary>
    /// Единица измерения может применяться для размера упаковки материала.
    /// </summary>
    ContainerSize = 1,


    /// <summary>
    /// Единица измерения может применяться для концентрации материала в жидкости.
    /// </summary>
    MaterialConcentration = 2,


    /// <summary>
    /// Единица измерения может применяться для количества материала.
    /// </summary>
    MaterialAmount = 4

  }
}
