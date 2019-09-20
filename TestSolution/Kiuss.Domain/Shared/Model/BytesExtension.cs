using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  public static class BytesExtension
  {
    public static bool BytesEquals(this IBitConvertable source, IBitConvertable target)
    {
      if (source == null && target == null)
        return true;

      if (source == null || target == null)
        return false;

      var sourceBytes = source.ObjectToBytes();
      var targetBytes = target.ObjectToBytes();

      if (sourceBytes.Length != targetBytes.Length)
        return false;

      return !sourceBytes.Where((t, i) => t != targetBytes[i]).Any();
    }

    public static string BytesToString(this IReadOnlyCollection<byte> arrInput)
    {
      var sOutput = new StringBuilder(arrInput.Count + arrInput.Count);
      foreach (var t in arrInput)
      {
        sOutput.Append(t.ToString("X2"));
      }
      return sOutput.ToString();
    }

  }
}
