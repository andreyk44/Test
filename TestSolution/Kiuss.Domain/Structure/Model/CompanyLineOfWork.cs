using System;
using Kiuss.Domain.Structure.Model.Refs;

namespace Kiuss.Domain.Structure.Model
{
  /// <summary>
  /// Организация занимается видом деятельности.
  /// </summary>
  /// <remarks>
  /// Описывает отношение NxM между Company и RefLineOfWork.
  /// </remarks>
  public class CompanyLineOfWork
  {
    private CompanyLineOfWork() { }

    public CompanyLineOfWork(Guid companyId, Guid lineOfWorkId)
    {
      CompanyId = companyId;
      LineOfWorkId = lineOfWorkId;
    }

    /// <summary>
    /// Организация.
    /// </summary>
    public Company Company { get; private set; }
    
    /// <summary>
    /// Идентификатор организации.
    /// </summary>
    public Guid CompanyId { get; private set; }

    /// <summary>
    /// Вид деятельности.
    /// </summary>
    public RefLineOfWork LineOfWork { get; private set; }

    /// <summary>
    /// Идентификатор видв деятельности.
    /// </summary>
    public Guid LineOfWorkId { get; private set; }
    
    public static CompanyLineOfWork New(Company company, RefLineOfWork lineOfWork)
      => new CompanyLineOfWork()
      {
        Company = company,
        LineOfWork = lineOfWork,
      };

    public static CompanyLineOfWork New(Guid companyId, Guid lineOfWorkId)
      => new CompanyLineOfWork()
      {
        CompanyId = companyId,
        LineOfWorkId = lineOfWorkId,
      };
  }
}
