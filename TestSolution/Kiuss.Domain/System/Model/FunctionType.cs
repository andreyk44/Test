namespace Kiuss.Domain.System.Model
{
  public enum FunctionType
  {
    Default = 0,
    ConfirmSection = 1,
    UnconfirmSection = -1,
    ApproveSection = 2,
    UnapproveSection = -2,
    ConfirmApproveSection = 3,
    UnapproveUnconfirmSection = -3
  }
}
