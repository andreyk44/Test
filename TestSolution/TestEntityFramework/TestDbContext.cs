using System;
using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestEntityFramework
{
  public class TestDbContext : DbContext
  {
    public TestDbContext(DbContextOptions options) : base(options) { }

    public DbSet<RefA> RefsA { get; set; }
    public DbSet<RefB> RefsB { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<RefA>().ToTable(null, "test");
      modelBuilder.Entity<RefB>().ToTable(null, "test");
    }
    private static void ConfigureOwned<TEntity, TDependentEntity>(CollectionOwnershipBuilder<TEntity, TDependentEntity> ownedBuilder, params string[] foreignKeys)
      where TEntity : class where TDependentEntity : class
    {
      ownedBuilder.HasForeignKey(foreignKeys);
      ownedBuilder.Property<int>("Id").ValueGeneratedOnAdd();
      ownedBuilder.HasKey(foreignKeys.Append("Id").ToArray());
    }
  }

  public class RefA : RefBase
  {
    private RefA(Guid id) : base(id) { }
    public string PropA { get; set; }
    public static RefA New(string name) => new RefA(Guid.NewGuid()) { PropA = name };
    public override string ToString() => $"PropA: {PropA}";
  }

  public class RefB : RefBase
  {
    private RefB(Guid id) : base(id) { }
    public string PropB { get; set; }
    public static RefB New(string name) => new RefB(Guid.NewGuid()) { PropB = name };
    public override string ToString() => $"PropB: {PropB}";
  }


}
