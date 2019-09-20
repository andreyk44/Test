using System;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model.AccountabilityAggregate;
using Kiuss.Domain.Structure.Model.Refs;

namespace Kiuss.Domain.Structure.Model
{
  /// <summary>
  /// �������� ��������.
  /// </summary>
  public class Wellsite : EntityBase<Guid>
  {
    public Wellsite(Guid id) : base(id) { }

    /// <summary>
    /// ��� �������������
    /// </summary>
    public OilfieldType OilfieldType { get; set; }

    /// <summary>
    /// ������������.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// �������� ��� �������� ��������� �������������.
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
    /// ������������� �����������-��������� ����� �� ��������. 
    /// </summary>
    /// <param name="administer">�����������-��������</param>
    /// <param name="period">������ �������, � ������� �������� ����������� ��������� � ���� ���������</param>
    public void SetAdminister(Company administer, DateTimeRange period)
    {
      AccountabilityParty.AddAdministerAccountability(administer.AccountabilityParty, period);
    }

    /// <summary>
    /// ������������� �����������-���������� ��� ���������� ����������� ����� �� ��������. 
    /// </summary>
    /// <param name="contractor">�����������-���������</param>
    /// <param name="period">������ �������, � ������� �������� ����������� ��������� � ���� ����������</param>
    /// <param name="lineOfWork">��� ������������ ��� ������� ����������� ��������� � ���� ����������</param>
    public void SetContractor(Company contractor, DateTimeRange period, RefLineOfWork lineOfWork)
    {
      AccountabilityParty.AddContractualAccountability(contractor.AccountabilityParty, lineOfWork, period);
    }
  }
}
