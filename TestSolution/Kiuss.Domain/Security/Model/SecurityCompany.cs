using System;
using Kiuss.Domain.Structure.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecurityCompany : SecurityObject
  {
    private SecurityCompany(Guid id) : base(id) { }

    public Company Company { get; private set; }
    public  Guid CompanyId { get; private set; }

    public static SecurityCompany New(Company company) => new SecurityCompany(Guid.NewGuid())
    {
      Type = SecurityObjectType.Company,
      Company = company,
      CompanyId = company.Id
    };
  
  }
}
