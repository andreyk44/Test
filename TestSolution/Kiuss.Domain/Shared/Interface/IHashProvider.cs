using System;
using System.Collections.Generic;
using System.Text;

namespace Kiuss.Domain.Shared.Interface
{
  public interface IHashProvider
  {
    byte[] ComputeHash(byte[] value);
  }
}
