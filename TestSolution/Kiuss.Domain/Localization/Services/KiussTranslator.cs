using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.Localization.Interfaces;
using Kiuss.Domain.Localization.Model;

namespace Kiuss.Domain.Localization.Services
{
  /// <summary>
  /// Логика трансляции текста с базового для модуля языка на другие языки.
  /// </summary>
  public class KiussTranslator
  {
    private readonly Dictionary<string, Dictionary<string, string>> _moduleItems;
    private readonly Dictionary<string, Dictionary<string, string>> _kiussItems;
    private readonly Dictionary<string, Dictionary<Guid, Dictionary<string, string>>> _sectionItems;

    private KiussTranslator(IList<KiussDictionary> dictionaries)
    {
      _kiussItems = (from d in dictionaries
          where d.Scope.Type == KiussScopeType.Global
          from item in d.Entries
          group item by item.TokenTo.LanguageId
        ).ToDictionary(g => g.Key, g => g.ToDictionary(e => e.TokenFrom.Value, e => e.TokenTo.Value));

      _moduleItems = (from d in dictionaries
          where d.Scope.Type == KiussScopeType.Module
          from item in d.Entries
          group item by item.TokenTo.LanguageId
        ).ToDictionary(g => g.Key, g => g.ToDictionary(e => e.TokenFrom.Value, e => e.TokenTo.Value));

      _sectionItems = (from d in dictionaries
          where d.Scope.Type == KiussScopeType.Section
          from item in d.Entries
          group (item, d.Scope.ScopeId) by item.TokenTo.LanguageId
        ).ToDictionary(g1 => g1.Key, g1 => g1.GroupBy(g => g.ScopeId)
          .ToDictionary(g2 => g2.Key, g2 => g2.ToDictionary(e => e.item.TokenFrom.Value, e => e.item.TokenTo.Value)));
    }

    public static KiussTranslator New(IList<KiussDictionary> dictionaries)
    {
      return new KiussTranslator(dictionaries);
    }

    public bool CanTranslateTo(string languageId) 
      => _sectionItems.ContainsKey(languageId) || _moduleItems.ContainsKey(languageId) || _kiussItems.ContainsKey(languageId);


    public ILocalizer GetModuleLocalizer(string languageId) =>
      new ModuleLocalizer(_moduleItems.ContainsKey(languageId) ? _moduleItems[languageId] : null,
                           _kiussItems.ContainsKey(languageId) ? _kiussItems[languageId] : null);

    public ILocalizer GetSectionLocalizer(string languageId, Guid sectionId) =>
      new SectionLocalizer(_sectionItems.ContainsKey(languageId) ? _sectionItems[languageId][sectionId] : null,
                            _moduleItems.ContainsKey(languageId) ? _moduleItems[languageId] : null,
                             _kiussItems.ContainsKey(languageId) ? _kiussItems[languageId] : null);

    private class ModuleLocalizer : ILocalizer
    {
      private readonly IDictionary<string, string> _moduleItems;
      private readonly IDictionary<string, string> _kiussItems;

      public ModuleLocalizer(IDictionary<string, string> moduleItems, IDictionary<string, string> kiussItems)
      {
        _moduleItems = moduleItems;
        _kiussItems = kiussItems;
      }

      string ILocalizer.Text(string baseLanguageText)
      {
        if (_moduleItems != null && _moduleItems.TryGetValue(baseLanguageText, out var localText))
          return localText;
        if (_kiussItems != null && _kiussItems.TryGetValue(baseLanguageText, out localText))
          return localText;
        return baseLanguageText;
      }
    }

    private class SectionLocalizer : ILocalizer
    {
      private readonly IDictionary<string, string> _sectionItems;
      private readonly IDictionary<string, string> _moduleItems;
      private readonly IDictionary<string, string> _kiussItems;

      public SectionLocalizer(IDictionary<string, string> sectionItems, IDictionary<string, string> moduleItems, IDictionary<string, string> kiussItems)
      {
        _sectionItems = sectionItems;
        _moduleItems = moduleItems;
        _kiussItems = kiussItems;
      }

      string ILocalizer.Text(string baseLanguageText)
      {
        if (_sectionItems != null && _sectionItems.TryGetValue(baseLanguageText, out var localText))
          return localText;
        if (_moduleItems != null && _moduleItems.TryGetValue(baseLanguageText, out localText))
          return localText;
        if (_kiussItems != null && _kiussItems.TryGetValue(baseLanguageText, out localText))
          return localText;
        return baseLanguageText;
      }
    }
  }
}
