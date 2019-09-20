using System;

namespace Kiuss.Domain.Shared.Model
{
  [Flags]
  public enum TransactionType
  {
    Undefined = 0,
    
    Initial = 1,
    
    Receipt = 2,

    Consumption = 3,

    Removal = 4,
  }
}
