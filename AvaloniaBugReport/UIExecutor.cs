using System;
using Avalonia.Threading;
using AvaloniaBugReport.Core;

namespace AvaloniaBugReport;

public class UIExecutor: IUIThreadExecutor
{
    public void Call(Action targetAction)
    {
        Dispatcher.UIThread.Post(targetAction);
    }
}