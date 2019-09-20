using System.Collections.Generic;
using System.Threading.Tasks;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.System.Interfaces
{
  public interface IModuleRepository
  {
    /// <summary>
    /// Извлекает из репозитория модуль КиУСС с данным системным именем.
    /// </summary>
    /// <param name="systemName">Системное имя модуля</param>
    /// <returns></returns>
    Task<KiussModule> FetchKiussModuleBySystemName(string systemName);

    /// <summary>
    /// Помещает в репозиторий данные о модулях и их составляющих(секций и функций).
    /// </summary>
    /// <param name="moduleImport">Данные о модулях.</param>
    /// <returns>Текстовое описание результата.</returns>
    Task<IList<string>> LoadModules(IModuleImport moduleImport);

  }
}
