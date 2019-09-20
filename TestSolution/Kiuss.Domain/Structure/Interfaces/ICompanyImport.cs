using System;
using System.Collections.Generic;

namespace Kiuss.Domain.Structure.Interfaces
{
  public interface ICompanyImport
  {
    /// <summary>
    /// Уникальный идентификатор компании.
    /// </summary>
    Guid Id { get; }
    /// <summary>
    /// Название компании.
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Список названий видов деятельности.
    /// </summary>
    IList<string> Lines { get; }
  }
}
