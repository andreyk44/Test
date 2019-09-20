using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Localization.Model
{
  public class KiussDictionaryEntry : ValueObject
  {
    public LanguageToken TokenFrom { get; private set; }
    public int TokenFromId { get; private set; }

    public LanguageToken TokenTo { get; private set; }
    public int TokenToId { get; private set; }

    public static KiussDictionaryEntry New(LanguageToken tokenFrom, LanguageToken tokenTo)
    {
      return new KiussDictionaryEntry()
      {
        TokenFrom = tokenFrom,
        TokenFromId = tokenFrom.Id,
        TokenTo = tokenTo,
        TokenToId = tokenTo.Id,
      };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return TokenFromId;
      yield return TokenToId;
    }
  }
}