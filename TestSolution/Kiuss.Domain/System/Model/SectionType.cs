namespace Kiuss.Domain.System.Model
{
  public enum SectionType
  {
    Undefined = 0,

    GeneralInfo = 0x0001,
    Equipment = 0x0002,
    OperationRoster = 0x0003,
    UnproductiveTime = 0x0004,
    PlannedWorks = 0x0005,
    SafetyEngineering = 0x0006,
    DrillMud = 0x0007,
    CleaningSystem = 0x0008,
    RockCuttingTool = 0x0009,
    WellStructure = 0x000A,

    BottomHoleAssembly = 0x000B,
    DirectionalDrilling = 0x000C,
    Trajectory = 0x000D,
    MeasureOfCasing = 0x000E,
    Cementation = 0x000F,
    Comments = 0x0010,
    SludgeAnalysis = 0x0011,
    Meteo = 0x0012,
    Reports = 0x0013,
  }
}
