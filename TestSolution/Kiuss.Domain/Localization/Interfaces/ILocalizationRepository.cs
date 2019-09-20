using System.Collections.Generic;
using System.Threading.Tasks;
using Kiuss.Domain.Localization.Model;

namespace Kiuss.Domain.Localization.Interfaces
{
  public interface ILocalizationRepository
  {
    Task<IList<KiussLanguage>> FetchAllLanguages();
    Task<IList<LanguageToken>> FetchAllLanguageTokens();
    Task<KiussDictionary> FetchKiussDictionary(string languageFromId, string languageToId, KiussScope scope);
    Task<IList<KiussDictionary>> FetchKiussDictionaryList(params KiussScope[] scopes);
    Task UpdateDictionary(KiussDictionary newDictionary, KiussDictionary oldDictionary);
    Task CommitChanges();
    void AddLanguageTokens(IList<LanguageToken> languageTokens);
  }
}
