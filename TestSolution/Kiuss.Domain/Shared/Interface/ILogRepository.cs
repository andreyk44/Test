using System.Threading.Tasks;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Shared.Interface
{
  public interface ILogRepository
  {
    Task AddLogItem(LogItem logItem);
  }
}
