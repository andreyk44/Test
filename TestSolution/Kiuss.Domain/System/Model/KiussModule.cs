using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.System.Model
{
  /// <summary>
  /// Модуль КиУСС.
  /// </summary>
  public class KiussModule : EntityBase<Guid>
  {
    private KiussModule(Guid id) : base(id) { }

    public ModuleType ModuleType { get; private set; }

    public string SystemName { get; private set; }

    public string Name { get; private set; }

    public IList<KiussSection> Sections { get; private set; }

    public static KiussModule New(Guid id, ModuleType moduleType, string systemName, string name, List<KiussSection> sections)
      => new KiussModule(id)
      {
        ModuleType = moduleType,
        SystemName = systemName,
        Name = name,
        Sections = sections
      };
  }
}
