using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.System.Model
{
  /// <summary>
  /// Раздел модуля КиУСС.
  /// </summary>
  public class KiussSection : EntityBase<Guid>
  {
    private KiussSection(Guid id) : base(id) { }

    /// <summary>
    /// Модуль КиУСС, которому принадлежит данный раздел.
    /// </summary>
    public KiussModule Module { get; private set; }
    /// <summary>
    /// Идентификатор модуля КиУСС, которому принадлежит данный раздел.
    /// </summary>
    public Guid ModuleId { get; private set; }

    /// <summary>
    /// Порядковый номер раздела в модуле.
    /// </summary>
    public int Position { get; private set; }

    /// <summary>
    /// Название раздела.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Аннотация раздела.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Тип раздела журнала.
    /// </summary>
    public SectionType SectionType { get; private set; }

    /// <summary>
    /// True- раздел активен, False - в разработке.
    /// </summary>
    public bool Active { get; private set; }

    /// <summary>
    /// Бизнес активности, связанные с разделом журанла. 
    /// </summary>
    public List<KiussFunction> Functions { get; private set; }

    public static KiussSection New(Guid id, int position, SectionType sectionType, string name, string description, bool active)
      => new KiussSection(id)
      {
        Position = position,
        Name = name,
        Description = description,
        SectionType = sectionType,
        Active = active,
        Functions = new List<KiussFunction>()
      };

    /// <summary>
    /// Добавляет несколько функций в раздел.
    /// </summary>
    /// <param name="functions"></param>
    public void AddFunctions(IEnumerable<KiussFunction> functions)
    {
      Functions = Functions ??  new List<KiussFunction>();
      Functions.AddRange(functions);
    }
  }
}
