using System;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model.AccountabilityAggregate;
using Kiuss.Domain.Structure.Model.Refs;

namespace Kiuss.Domain.Structure.Model
{
  /// <summary>
  /// Нефтяная скважина.
  /// </summary>
  public class Wellsite : EntityBase<Guid>
  {
    public Wellsite(Guid id) : base(id) { }

    /// <summary>
    /// Тип месторождения
    /// </summary>
    public OilfieldType OilfieldType { get; set; }

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Скважина как участник отношения подотчетности.
    /// </summary>
    public WellsiteParty AccountabilityParty { get; set; }


    public static Wellsite New(string name, OilfieldType oilfieldType)
      => New(Guid.NewGuid(), name, oilfieldType);

    public static Wellsite New(Guid id, string name, OilfieldType oilfieldType)
    {
      var wellsite = new Wellsite(id)
      {
        Name = name,
        OilfieldType = oilfieldType
      };
      var party = WellsiteParty.New(wellsite);
      wellsite.AccountabilityParty = party;
      return wellsite;
    }

    public static Wellsite New(Guid id, OilfieldType oilfieldType, string name, WellsiteParty accountabilityParty) => new Wellsite(id)
      {
        OilfieldType = oilfieldType,
        Name = name,
        AccountabilityParty = accountabilityParty
      };
    
    /// <summary>
    /// Устанавливает организацию-заказчика работ на скважине. 
    /// </summary>
    /// <param name="administer">Организация-заказчик</param>
    /// <param name="period">Период времени, в течении которого организация выступает в роли заказчика</param>
    public void SetAdminister(Company administer, DateTimeRange period)
    {
      AccountabilityParty.AddAdministerAccountability(administer.AccountabilityParty, period);
    }

    /// <summary>
    /// Устанавливает организацию-подрядчика для выполнения определённых работ на скважине. 
    /// </summary>
    /// <param name="contractor">Организация-подрядчик</param>
    /// <param name="period">Период времени, в течении которого организация выступает в роли подрядчика</param>
    /// <param name="lineOfWork">Вид деятельности для которой организация выступает в роли подрядчика</param>
    public void SetContractor(Company contractor, DateTimeRange period, RefLineOfWork lineOfWork)
    {
      AccountabilityParty.AddContractualAccountability(contractor.AccountabilityParty, lineOfWork, period);
    }
  }
}
