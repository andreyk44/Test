using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Localization.Model
{
  public class LanguageToken : EntityBase<int>
  {
    private LanguageToken(int id) : base(id) { }

    public KiussLanguage Language { get; private set; }
    public string LanguageId { get; private set; }

    public string Value { get; private set; }

    public static LanguageToken New(string value, KiussLanguage language)
    {
      return new LanguageToken(0)
      {
        Value = value,
        Language = language,
        LanguageId = language.Id
      };
    }
  }
}