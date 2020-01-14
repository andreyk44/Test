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
      modelBuilder.Entity<Header>()
        .ToTable(null, "test");

      modelBuilder.Entity<Detail>()
        .ToTable(null, "test")
        .Property<int>("Id").ValueGeneratedOnAdd().IsRequired();
      modelBuilder.Entity<Detail>()
        .HasKey("Id");
      modelBuilder.Entity<Detail>()
        .Property<Guid>("HeaderId").IsRequired();

      modelBuilder.Entity<Header>()
        .HasMany(e => e.Details)
        .WithOne()
        .HasForeignKey("HeaderId")
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Detail>()
        .HasDiscriminator(e => e.Type)
        .HasValue<Detail_1>("1")
        .HasValue<Detail_2>("2")
        ;
    }
  }

  public class Header : EntityBase<Guid>
  {
    public Header() : base(Guid.NewGuid()) { }

    public string Name { get; private set; }
    public IList<Detail> Details { get; private set; } = new List<Detail>();

    public static Header New(string name, IList<Detail> details)
    {
      return new Header()
      {
        Name = name,
        Details = details
      };
    }
    public override string ToString() => Name + $"({string.Join(',', Details)})";
  }

  public abstract class Detail : ValueObject
  {
    protected Detail()
    {
      Type = "";
    }
      
    public string Name { get; protected set; }
    public string Type { get; protected set; }
    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Type;
      yield return Name;
    }
    public override string ToString() => $"{Type}:{Name}";
  }

  public class Detail_1 : Detail
  {
    protected Detail_1()
    {
      Type = "1";
    }
    public int Data { get; private set; }
    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Type;
      yield return Name;
      yield return Data;
    }
    public override string ToString() => $"{Type}:{Name}:{Data}";
    public static Detail_1 New(string name, int data) => new Detail_1() { Name = name, Data = data };
  }


  public class Detail_2 : Detail
  {
    protected Detail_2()
    {
      Type = "2";
    }
    public DateTime Data { get; protected set; }
    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Type;
      yield return Name;
      yield return Data;
    }
    public override string ToString() => $"{Type}:{Name}:{Data}";
    public static Detail_2 New(string name, DateTime data) => new Detail_2() { Name = name, Data = data };
  }
}
