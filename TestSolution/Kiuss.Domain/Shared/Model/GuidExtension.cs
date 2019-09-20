using System;

namespace Kiuss.Domain.Shared.Model
{
    public static class GuidExtension
    {
      public static Guid? NullWhenEmpty(this Guid? guid) => 
        guid.HasValue && guid.Value.Equals(Guid.Empty) ? null : guid;
    }
}
