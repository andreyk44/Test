using System;
using System.Collections.Generic;
using Kiuss.Domain.Shared.Model;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;

namespace TestEntityFramework
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteData();

      using (var ctx = TestDatabase.GetDbContext())
      {
        foreach (var r in ctx.RefsA)
        {
          Console.WriteLine(r);
        }

        foreach (var r in ctx.RefsB)
        {
          Console.WriteLine(r);
        }

      }

      Console.WriteLine("Press any key..");
      Console.ReadKey();
    }

    private static void WriteData()
    {
      using (var ctx = TestDatabase.GetDbContext())
      {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        WriteTargets(ctx);
      }
    }

    private static void WriteTargets(TestDbContext ctx)
    {
      object[] refs = { RefA.New("A"), RefB.New("B") };
      ctx.AddRange(refs);
      ctx.SaveChanges();
    }

  }
}
