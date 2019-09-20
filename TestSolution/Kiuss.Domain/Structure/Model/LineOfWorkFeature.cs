using System;

namespace Kiuss.Domain.Structure.Model
{
  [Flags]
  public enum LineOfWorkFeature
  {
    Undefined = 0,
    EquipmentManufacturing = 0x00000001, // Производство оборудования
    ContractorWorks = 0x10000000,        // Контрактные работы (любые)

    DirectionalDrilling = 0x10000001, // Контрактные работы - Наклонно-направленное бурение и телеметрия
    BoreholeLogging = 0x10000002,     // Контрактные работы - ГИС на скважине

  }
}
