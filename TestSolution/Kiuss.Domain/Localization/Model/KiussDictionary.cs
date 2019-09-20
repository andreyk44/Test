using System.Collections.Generic;
using Kiuss.Domain.Shared.Interface;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Localization.Model
{
  public class KiussDictionary : EntityBase<int>, IEquatableProperties<KiussDictionary, int>
  {
    private KiussDictionary(int id) : base(id) { }

    public KiussLanguage LanguageFrom { get; private set; }
    public string LanguageFromId { get; private set; }

    public KiussLanguage LanguageTo { get; private set; }
    public string LanguageToId { get; private set; }

    public KiussScope Scope { get; private set; }

    public IList<KiussDictionaryEntry> Entries { get; private set; }

    public static KiussDictionary New(int id, KiussLanguage languageFrom, KiussLanguage languageTo, KiussScope scope)
    {
      return new KiussDictionary(id)
      {
        LanguageFrom = languageFrom,
        LanguageFromId = languageFrom.Id,
        LanguageTo = languageTo,
        LanguageToId = languageTo.Id,
        Scope = scope 
      };
    }

    public void AddEntry(LanguageToken from, LanguageToken to)
    {
      Entries = Entries ?? new List<KiussDictionaryEntry>();
      Entries.Add(KiussDictionaryEntry.New(from, to));
    }


    bool IEquatableProperties<KiussDictionary, int>.PropertiesEqual(KiussDictionary other)
    {
      return LanguageFromId == other.LanguageFromId &&
             LanguageToId == other.LanguageToId &&
             Scope == other.Scope &&
             Entries.EquivalentValuesTo(other.Entries);
    }

    void IEquatableProperties<KiussDictionary, int>.SyncProperties(KiussDictionary other)
    {
      LanguageFromId = other.LanguageFromId;
      LanguageToId = other.LanguageToId;
      Scope = other.Scope;
      Entries.SyncValues(other.Entries);
    }

    KiussDictionary IEquatableProperties<KiussDictionary, int>.GetCopy()
    {
      return new KiussDictionary(Id)
      {
        LanguageFromId = LanguageFromId,
        LanguageFrom = LanguageFrom,
        LanguageToId = LanguageToId,
        LanguageTo = LanguageTo,
        Scope = Scope,
        Entries = Entries.GetValuesCopy()
      };
    }
  }
}