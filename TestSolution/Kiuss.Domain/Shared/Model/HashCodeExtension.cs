using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  public static class HashCodeExtension
  {
    public static string GetHashString(this IBitConvertable source, IHashProvider provider) 
      => provider.ComputeHash(source.ObjectToBytes()).BytesToString();

  }
}
