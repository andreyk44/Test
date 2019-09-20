using System;
using System.Collections.Generic;

namespace TestEntityFramework
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteData();

      using (var ctx = TestDatabase.GetDbContext())
      {
        foreach (var header in ctx.Headers)
        {
          Console.WriteLine(header);
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
      ctx.Headers.Add(HeaderA.New("Header_A"));
      ctx.Headers.Add(HeaderB.New(new List<Detail>()
      {
        Detail.New("Datail_B_1"),
        Detail.New("Datail_B_2")
      }));

      ctx.SaveChanges();
    }

  }
}
