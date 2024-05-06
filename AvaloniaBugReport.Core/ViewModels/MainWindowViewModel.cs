using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBugReport.Core.ViewModels;

public partial class MainWindowViewModel: ObservableObject
{
    [ObservableProperty]
    private int testInt = 5;
    
    public IUIThreadExecutor? uiExecutor;
    
    public MainWindowViewModel()
    {
        Task calculateTask = Calculate();
    }
    
    private async Task Calculate()
    {
        await Task.Delay(1000);
        uiExecutor?.Call(() => TestInt = 10);
    }
}