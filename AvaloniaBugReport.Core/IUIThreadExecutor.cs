namespace AvaloniaBugReport.Core;

public interface IUIThreadExecutor
{
    void Call(Action targetAction);
}