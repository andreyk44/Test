namespace Kiuss.Domain.Integration.Model
{
  /// <summary>
  /// Тип очереди для .
  /// </summary>
  public enum EventQueueType
  {
    Undefined = 0,
    Output = 1,
    Sent = 2,
    Input = 3,
    Processed = 4
  }
}