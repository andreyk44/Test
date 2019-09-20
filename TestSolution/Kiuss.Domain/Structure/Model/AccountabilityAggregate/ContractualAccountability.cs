using System;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model.Refs;

namespace Kiuss.Domain.Structure.Model.AccountabilityAggregate
{
  /// <summary>
  /// Представляет отношение подотчетности 'быть подрядчиком работ на буровой скважине'.
  /// </summary>
  /// <remarks>
  /// Commissioner - Wellsite
  /// Responsible - Company
  /// </remarks>
  public class ContractualAccountability : Accountability
  {
    public ContractualAccountability(Guid id) : base(id) { }

    /// <summary>
    /// Вид деятельности.
    /// </summary>
    public RefLineOfWork LineOfWork { get; set; }
    
    /// <summary>
    /// Идентификатор вида деятельности.
    /// </summary>
    public Guid? LineOfWorkId { get; set; }

    public static ContractualAccountability New(AccountabilityParty commisioner, AccountabilityParty responsible, RefLineOfWork lineOfWork, DateTimeRange period)
    {
      return new ContractualAccountability(Guid.NewGuid())
      {
        AccountabilityType = AccountabilityType.Contractual,
        Commisioner = commisioner,
        Responsible = responsible,
        Period = period,
        LineOfWork = lineOfWork
      };
    }

    public static ContractualAccountability New(Guid commisionerId, Guid responsibleId, DateTimeRange period, Guid lineOfWork)
    {
      return new ContractualAccountability(Guid.NewGuid())
      {
        AccountabilityType = AccountabilityType.Contractual,
        CommisionerId = commisionerId,
        ResponsibleId = responsibleId,
        Period = period,
        LineOfWorkId = lineOfWork
      };
    }

    public static ContractualAccountability New(Guid id, Guid commisionerId, Guid responsibleId, DateTimeRange period, Guid lineOfWork)
    {
      return new ContractualAccountability(id)
      {
        AccountabilityType = AccountabilityType.Contractual,
        CommisionerId = commisionerId,
        ResponsibleId = responsibleId,
        Period = period,
        LineOfWorkId = lineOfWork
      };
    }

  }
}
