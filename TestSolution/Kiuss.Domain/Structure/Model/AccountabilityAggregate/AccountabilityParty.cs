using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Structure.Model.AccountabilityAggregate
{
  /// <summary>
  /// Участник отношения подотчетности.
  /// </summary>
  public class AccountabilityParty : EntityBase<Guid>
  {
    protected AccountabilityParty(Guid id, PartyType partyType) : base(id)
    {
      PartyType = partyType;
    }
    
    /// <summary>
    /// Тип участника отношения подотчетности.
    /// </summary>
    /// <remarks>
    /// Company, Wellsite,..
    /// </remarks>
    public PartyType PartyType { get; private set; }

    /// <summary>
    /// Набор отношений подотчетности, в которых данный участник выступает как уполномоченный.
    /// </summary>
    public IList<Accountability> CommissionerAccountabilities { get; private set; }

    /// <summary>
    /// Набор отношений подотчетности, в которых данный участник выступает как отвественный.
    /// </summary>
    public IList<Accountability> ResponsibleAccountabilities { get; private set; }

    protected void AddCommissioner(Accountability accountability)
    {
      if (CommissionerAccountabilities == null)
        CommissionerAccountabilities = new List<Accountability>();
      CommissionerAccountabilities.Add(accountability);
    }

    protected void AddResponsible(Accountability accountability)
    {
      if (ResponsibleAccountabilities == null)
        ResponsibleAccountabilities = new List<Accountability>();
      ResponsibleAccountabilities.Add(accountability);
    }

  }
}
