using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model;
using Kiuss.Domain.Structure.Model.AccountabilityAggregate;

namespace Kiuss.Domain.Structure.Interfaces
{
  public interface IStructureRepository
  {
    Task<Wellsite> FetchWellsiteByKey(Guid wellsiteId);
    Task<IList<Wellsite>> GetWellsiteList(OilfieldType type);
    Task<Company> GetCompanyByKey(Guid id);

    Task<IList<Company>> GetVendorList();

    Task<IList<Company>> GetCompanyListLineOfWork(Guid lineOfWork);

    Task AddCompanyVendor(Company company);


    Task<IList<Company>> GetWellsiteCompanyByType(Guid wellsiteId, DateTime date, AccountabilityType type);

    /// <summary>
    /// Помещает в репозиторий данные об организациях и их видах деятельности.
    /// </summary>
    /// <param name="companyImport">Данные об организациях и их видах деятельности.</param>
    /// <returns>Текстовое описание результата.</returns>
    Task<IList<string>> LoadCompanies(IList<ICompanyImport> companyImport);

    /// <summary>
    /// Помещает в репозиторий данные о скважинах, заказчиках и подрядчиках.
    /// </summary>
    /// <param name="wellsiteImport">Данные о скважинах, заказчиках и подрядчиках.</param>
    /// <returns>Текстовое описание результата.</returns>
    Task<IList<string>> LoadWellsites(IWellsiteImport wellsiteImport);

    Task<IList<Accountability>> FetchComissionerAccountabilities(Guid wellsiteId, DateTime date);
  }
}
