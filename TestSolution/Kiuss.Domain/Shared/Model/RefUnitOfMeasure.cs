namespace Kiuss.Domain.Shared.Model
{
  public class RefUnitOfMeasure : EntityBase<string>
  {
    private RefUnitOfMeasure(string id) : base(id) { }

    public UomFeature Features { get; private set; }

    public static RefUnitOfMeasure New(string code, UomFeature features = UomFeature.Undefined)
    {
      return new RefUnitOfMeasure(code) { Features = features };
    }
  }
}
