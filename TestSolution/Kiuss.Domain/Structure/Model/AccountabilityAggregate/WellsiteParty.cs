using System;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model.Refs;

namespace Kiuss.Domain.Structure.Model.AccountabilityAggregate
{
  /// <summary>
  /// Буровая скважина как участник отношения подотчетности.
  /// </summary>
  public class WellsiteParty : AccountabilityParty
  {
    /// <summary>
    /// Буровая скважина.
    /// </summary>
    public Wellsite Wellsite { get; private set; }
    
    /// <summary>
    /// Идентификатор буровой скважины.
    /// </summary>
    public Guid WellsiteId { get; private set; }


    private WellsiteParty(Guid id) : base(id, PartyType.Wellsite) { }

    public static WellsiteParty New(Wellsite wellsite) => new WellsiteParty(Guid.NewGuid())
    {
      Wellsite = wellsite,
      WellsiteId = wellsite.Id
    };

    public static WellsiteParty New(Guid id, Wellsite wellsite) => new WellsiteParty(id)
    {
      Wellsite = wellsite,
      WellsiteId = wellsite.Id,
    };

    public static WellsiteParty New(Guid id, Guid wellsiteId) => new WellsiteParty(id)
    {
      WellsiteId = wellsiteId
    };

    public void AddContractualAccountability(CompanyParty companyParty, RefLineOfWork lineOfWork, DateTimeRange period)
    {
      AddCommissioner(ContractualAccountability.New(this, companyParty, lineOfWork, period));
    }

    public void AddAdministerAccountability(CompanyParty companyParty, DateTimeRange period)
    {
      AddCommissioner(AdministerAccountability.New(this, companyParty, period));
    }
  }
}
