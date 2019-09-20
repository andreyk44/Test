using System;
using System.Threading.Tasks;
using Kiuss.Domain.Shared.Model;

namespace Kiuss.Domain.Shared.Interface
{
  public interface IMediaRepository
  {
    Task AddMediaItem(MediaItem mediaItem);
    Task<MediaItem> GetMediaItem(Guid id);
  }
}
