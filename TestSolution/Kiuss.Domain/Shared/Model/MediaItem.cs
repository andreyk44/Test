using System;

namespace Kiuss.Domain.Shared.Model
{
  /// <summary>
  /// Медиа данные.
  /// </summary>
  public class MediaItem : EntityBase<Guid>
  {
    public string ContentType { get; private set; }
    public long Length { get; private set; }
    public string FileName { get; private set; }
    public byte[] Data { get; private set; }

    private MediaItem() { }
    public static MediaItem New(string contentType, long length, string fileName, byte[] data)
    {
      return new MediaItem()
      {
        ContentType = contentType,
        Length = length,
        FileName = fileName,
        Data = data,
      };
    }

    public static MediaItem New(Guid id, string contentType, long length, string fileName, byte[] data)
    {
      return new MediaItem()
      {
        Id = id,

        ContentType = contentType,
        Length = length,
        FileName = fileName,
        Data = data,
      };
    }
  }
}
