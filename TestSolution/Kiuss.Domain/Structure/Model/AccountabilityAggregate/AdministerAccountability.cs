using System;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Structure.Model.AccountabilityAggregate
{
  /// <summary>
  /// Представляет отношение подотчетности 'быть заказчиком работ на буровой скважине'.
  /// </summary>
  /// <remarks>
  /// Commissioner - Wellsite
  /// Responsible - Company
  /// </remarks>
  public class AdministerAccountability : Accountability
  {
    public AdministerAccountability(Guid id) : base(id) { }

    public static AdministerAccountability New(AccountabilityParty commisioner, AccountabilityParty responsible, DateTimeRange period)
    {
      return new AdministerAccountability(Guid.NewGuid())
      {
        AccountabilityType = AccountabilityType.Administer,
        Commisioner = commisioner,
        Responsible = responsible,
        Period = period
      };
    }

    public static AdministerAccountability New(Guid commisionerId, Guid responsibleId, DateTimeRange period)
    {
      return new AdministerAccountability(Guid.NewGuid())
      {
        AccountabilityType = AccountabilityType.Administer,
        CommisionerId = commisionerId,
        ResponsibleId = responsibleId,
        Period = period
      };
    }

    public static AdministerAccountability New(Guid id , Guid commisionerId, Guid responsibleId, DateTimeRange period)
    {
      return new AdministerAccountability(id)
      {
        AccountabilityType = AccountabilityType.Administer,
        CommisionerId = commisionerId,
        ResponsibleId = responsibleId,
        Period = period
      };
    }

  }
}
