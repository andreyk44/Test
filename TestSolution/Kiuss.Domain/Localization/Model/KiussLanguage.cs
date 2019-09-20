using System;
using Kiuss.Domain.Shared.Interface;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Localization.Model
{
  public class KiussLanguage : EntityBase<string>, IEquatableProperties<KiussLanguage, string>
  {
    private KiussLanguage(string id, string name) : base(id)
    {
      Name = name;
    }
    public string Name { get; private set; }
    public static KiussLanguage New(string id, string name)
    {
      return new KiussLanguage(id, name);
    }

    bool IEquatableProperties<KiussLanguage, string>.PropertiesEqual(KiussLanguage other)
    {
      throw new NotImplementedException();
    }

    void IEquatableProperties<KiussLanguage, string>.SyncProperties(KiussLanguage other)
    {
      throw new NotImplementedException();
    }

    KiussLanguage IEquatableProperties<KiussLanguage, string>.GetCopy()
    {
      throw new NotImplementedException();
    }
  }
}