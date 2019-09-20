using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.System.Model;

namespace Kiuss.Domain.Security.Model
{
  public class SecurityMap 
  {
    private readonly SecurityModule _securityModule;
    private readonly IDictionary<Guid, SecurityCompany> _securityCompanies;
    private readonly IList<SecurityMapItem> _securityMapItems;

    public SecurityMap(IList<SecurityMapItem> securityMapItems)
    {
      _securityMapItems = securityMapItems;
      _securityModule = securityMapItems.Select(e => e.SecurityObject).OfType<SecurityModule>().FirstOrDefault();
      _securityCompanies = securityMapItems.Select(e => e.SecurityObject).OfType<SecurityCompany>().Distinct()
        .ToDictionary(e => e.CompanyId);
    }

    public bool Any() => _securityMapItems != null && _securityMapItems.Any();


    public IList<SecuritySection> GetSecuritySections() => _securityModule.Sections();
    public SecuritySection GetSecuritySection(Guid sectionId) => _securityModule.Section(sectionId);

    public bool IsCompanyAccessGranted(Guid companyId, SecurityGroup securityGroup)
    {
      if (!_securityCompanies.TryGetValue(companyId, out var securityCompany))
        return false;
      return IsAccessGranted(securityCompany, securityGroup);
    }

    public bool IsModuleAccessGranted(SecurityRole securityRole) => IsAccessGranted(_securityModule, securityRole);
    public bool IsModuleWriteAccessGranted(SecurityRole securityRole) => IsAccessGranted(_securityModule, securityRole, AccessLevel.ReadWrite);
    public bool IsSectionAccessGranted(Guid sectionId, SecurityRole securityRole) => IsAccessGranted(_securityModule.Section(sectionId), securityRole);
    public bool IsSectionWriteAccessGranted(Guid sectionId, SecurityRole securityRole) => IsAccessGranted(_securityModule.Section(sectionId), securityRole, AccessLevel.ReadWrite);
    public bool IsFunctionAccessGranted(Guid sectionId, FunctionType functionType, SecurityRole securityRole) => IsAccessGranted(_securityModule.Function(sectionId, functionType), securityRole);


    private bool IsAccessGranted(SecurityObject securityObject, SecuritySubject securitySubject, AccessLevel accessLevel = AccessLevel.Default)
    {
      return _securityMapItems.Any(ar => ar.SecurityObject == securityObject
                              && ar.SecuritySubject == securitySubject
                              && (int)ar.AccessLevel >= (int)accessLevel);
    }

  }
}
