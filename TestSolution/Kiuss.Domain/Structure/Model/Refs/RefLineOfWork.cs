using System;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Structure.Model.Refs
{
  /// <summary>
  /// Вид деятельности.
  /// </summary>
  public class RefLineOfWork : RefBase
  {
    private RefLineOfWork(Guid id) : base(id) { }

    /// <summary>
    /// Аббревиатура 
    /// </summary>
    public string Abbreviation { get; set; }

    public LineOfWorkFeature Features { get; set; }

    public static RefLineOfWork New(string sid, string name, string abbreviation, LineOfWorkFeature features)
      => new RefLineOfWork(Guid.Parse(sid))
      {
        Name = name,
        Abbreviation = abbreviation,
        Features = features
      };
  }
}
