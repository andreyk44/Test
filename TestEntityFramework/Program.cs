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
        foreach (var header in ctx.Headers.Include(e => e.Details())
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
      var h = Header.New("Header-1", new List<Detail>()
      {
        Detail_1.New("1", 999),
        Detail_2.New("2", DateTime.Now),
      });
      ctx.Headers.Add(h);
      ctx.SaveChanges();
    }

  }
}
