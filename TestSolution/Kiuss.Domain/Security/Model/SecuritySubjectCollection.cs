using System.Collections.Generic;
using System.Linq;

namespace Kiuss.Domain.Security.Model
{
  public class SecuritySubjectCollection
  {
    private readonly List<SecuritySubject> _securitySubjects = new List<SecuritySubject>();

    public void AddRole(string groupId)
    {
      _securitySubjects.Add(SecurityRole.New(groupId));
    }

    public void AddGroup(string groupId)
    {
      _securitySubjects.Add(SecurityGroup.New(groupId));
    }

    public void Add(SecuritySubject securitySubject)
    {
      _securitySubjects.Add(securitySubject);
    }


    public SecuritySubject this[string id]
    {
      get { return _securitySubjects.FirstOrDefault(ss => ss.Id == id); }
    }

    public IEnumerable<SecuritySubject> All()
    {
      return _securitySubjects.AsReadOnly();
    }

    public void AddSecuritysubjects(IList<SecuritySubject> securitySubjects)
    {
      _securitySubjects.AddRange(securitySubjects);
    }

    public SecurityRole Role(string id)
    {
      return _securitySubjects.OfType<SecurityRole>().FirstOrDefault(sr => sr.Id == id);
    }
  }
}
