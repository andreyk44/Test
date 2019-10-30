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
        .HasDiscriminator<string>("discr")
        .HasValue<HeaderA>("A")
        .HasValue<HeaderAA>("AA")
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

  public enum HeaderType
  {
    Undefined,
    TypeA,
    TypeB
  }

  public class Header : EntityBase<Guid>
  {
    protected Header(Guid id) : base(id) { }
    protected string Discr = "";
    public HeaderType Type { get; protected set; } = HeaderType.Undefined;
  }

  public class HeaderA : Header
  {
    public HeaderA() : base(Guid.NewGuid())
    {
      Type = HeaderType.TypeA;
      Discr = "A";
    }
    public string Name { get; protected set; }
    public static HeaderA New(string name) => new HeaderA()
    {
      Name = name
    };
    public override string ToString() => Name;
  }

  public class HeaderAA : HeaderA
  {
    public HeaderAA()
    {
      Discr = "AA";
    }
    public string ExtraProp { get; set; }
    public static HeaderAA New(string name, string extraProp) => new HeaderAA()
    {
      Name = name,
      ExtraProp = extraProp
    };
    public override string ToString() => $"{Name}('{ExtraProp}')";
  }


  public class HeaderB : Header
  {
    public HeaderB() : base(Guid.NewGuid())
    {
      Type = HeaderType.TypeB;
      Discr = "B";
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
