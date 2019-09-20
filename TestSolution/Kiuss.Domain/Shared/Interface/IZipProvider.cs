using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiuss.Domain.Shared.Interface
{
  public interface IZipProvider
  {
    Task<(byte[] Data, string Method)> Zip(byte[] value);
  }
}
