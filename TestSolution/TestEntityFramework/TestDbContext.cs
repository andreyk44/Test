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

    public DbSet<Header> Headers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Header>().ToTable(null, "test");

      modelBuilder.Entity<Header>()
        .HasDiscriminator(e => e.Type)
        .HasValue<HeaderA>("A")
        .HasValue<HeaderB>("B")
        ;

      modelBuilder.Entity<HeaderB>().OwnsMany(e => e.Details, builder => ConfigureOwned(builder, "HeaderId"));

    }
    private static void ConfigureOwned<TEntity, TDependentEntity>(CollectionOwnershipBuilder<TEntity, TDependentEntity> ownedBuilder, params string[] foreignKeys)
      where TEntity : class where TDependentEntity : class
    {
      ownedBuilder.HasForeignKey(foreignKeys);
      ownedBuilder.Property<int>("Id").ValueGeneratedOnAdd();
      ownedBuilder.HasKey(foreignKeys.Append("Id").ToArray());
    }
  }

  public class Header : EntityBase<Guid>
  {
    protected Header(Guid id) : base(id) { }

    public string Type { get; protected set; }
  }

  public class HeaderA : Header
  {
    public HeaderA() : base(Guid.NewGuid())
    {
      Type = "A";
    }

    public string Name { get; private set; }

    public static HeaderA New(string name) => new HeaderA()
    {
      Name = name
    };
    public override string ToString() => Name;
  }

  public class HeaderB : Header
  {
    public HeaderB() : base(Guid.NewGuid())
    {
      Type = "B";
    }

    public IList<Detail> Details { get; private set; }

    public static HeaderB New(IList<Detail> details) => new HeaderB()
    {
      Details = details
    };
    public override string ToString() => $"({string.Join(',', Details)})";
  }


  public class Detail : ValueObject
  {
    protected Detail() { }
    public string Value { get; protected set; }
    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Value;
    }
    public static Detail New(string value) => new Detail()
    {
      Value = value
    };

    public override string ToString() => Value;
  }




}
