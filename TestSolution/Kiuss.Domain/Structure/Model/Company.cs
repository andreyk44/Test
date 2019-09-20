using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model.AccountabilityAggregate;
using Kiuss.Domain.Structure.Model.Refs;

namespace Kiuss.Domain.Structure.Model
{
  /// <inheritdoc />
  /// <summary>
  /// Организация
  /// </summary>
  /// <remarks>
  /// Производитель оборудования и пр.
  /// </remarks>
  public class Company : EntityBase<Guid>
  {
    private Company(Guid id) : base(id) { }

    /// <summary>
    /// Наименование.
    /// </summary>+
    public string Name { get; set; }


    /// <summary>
    /// Набор видов деятельностей, осуществляемых компанией.
    /// </summary>
    public IList<CompanyLineOfWork> LinesOfWork { get; set; }


    /// <summary>
    /// Организация как участник отношения подотчетности.
    /// </summary>
    public CompanyParty AccountabilityParty { get; set; }


    public static Company Empty()
      => new Company(Guid.Empty);

    public static Company New(string name)
      => New(Guid.NewGuid(), name);

    public static Company New(Guid id, string name)
    {
      var company = new Company(id)
      {
        Name = name,
      };
      var party = CompanyParty.New(company);
      company.AccountabilityParty = party;
      return company;
    }

    public void AddLineOfWork(RefLineOfWork lineOfWork)
    {
      if (LinesOfWork == null)
        LinesOfWork = new List<CompanyLineOfWork>();
      LinesOfWork.Add(CompanyLineOfWork.New(this, lineOfWork));
    }
  }
}
