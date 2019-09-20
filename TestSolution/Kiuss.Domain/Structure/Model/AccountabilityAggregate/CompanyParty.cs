using System;

namespace Kiuss.Domain.Structure.Model.AccountabilityAggregate
{
  /// <summary>
  /// Организация как участник отношения подотчетности.
  /// </summary>
  public class CompanyParty : AccountabilityParty
  {
    /// <summary>
    /// Организация.
    /// </summary>
    public Company Company { get; private set; }

    /// <summary>
    /// Идентификатор организации.
    /// </summary>
    public Guid CompanyId { get; private set; }

    private CompanyParty(Guid id) : base(id, PartyType.Company) { }

    public static CompanyParty New(Company company) => new CompanyParty(Guid.NewGuid())
    {
      Company = company,
      CompanyId = company.Id
    };

    public static CompanyParty New(Guid id, Company company) => new CompanyParty(id)
    {
      Company = company,
      CompanyId = company.Id
    };

    public static CompanyParty New(Guid id, Guid companyId) => new CompanyParty(id)
    {
      CompanyId = companyId
    };

  }
}
