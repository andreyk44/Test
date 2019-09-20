using System.Collections.Generic;
using System.Threading.Tasks;
using Kiuss.Domain.Security.Model;

namespace Kiuss.Domain.Security.Interfaces
{
  public interface ISecurityRepository
  {
    /// <summary>
    /// Помещает в репозиторий данные о группах и ролях безопасности. 
    /// </summary>
    /// <param name="securityImport">Данные о группах и ролях.</param>
    /// <returns>Текстовое описание результата.</returns>
    Task<IList<string>> LoadSecurity(ISecurityImport securityImport);

    /// <summary>
    /// Помещает в репозиторий данные о пользователях. 
    /// </summary>
    /// <param name="userImport">Данные о пользователях.</param>
    /// <returns>Текстовое описание результата.</returns>
    Task<IList<string>> LoadUsers(IList<IUserImport> userImport);

    /// <summary>
    /// Извлекает карту прав доступа для указанного модуля.
    /// </summary>
    /// <param name="moduleSysName">Систеиное имя модуля</param>
    /// <returns></returns>
    Task<SecurityMap> FetchSecurituMap(string moduleSysName);


    /// <summary>
    /// Ищет пользователя по его доменному имени.
    /// </summary>
    /// <returns></returns>
    Task<KiussUser> FetchUser(string loginName, string domainName);

    Task<KiussUser[]> FetchUserByFeature(KiussUserFeature features);

    Task AddUser(KiussUser user);
  }
}
