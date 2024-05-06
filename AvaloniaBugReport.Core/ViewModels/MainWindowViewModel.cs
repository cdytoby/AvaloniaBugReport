using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using ObservableCollections;

namespace AvaloniaBugReport.Core.ViewModels;

public partial class MainWindowViewModel: ObservableObject
{
    [ObservableProperty]
    private int testInt = 5;
    
    [ObservableProperty]
    private INotifyCollectionChangedSynchronizedView<string> testNotifiedEnumerable;
    
    [ObservableProperty]
    private ObservableCollection<string> testCollection = [];
    
    public IUIThreadExecutor? uiExecutor;
    
    private ObservableList<string> testList = [];
    
    public MainWindowViewModel()
    {
        TestNotifiedEnumerable = testList.CreateView(x => x).ToNotifyCollectionChanged();
        TestNotifiedEnumerable.CollectionChanged += TestNotifiedEnumerableOnCollectionChanged;
        
        testCollection.Add("Should Work 1");
        testCollection.Add("Should Work 2");
        
        Task calculateTask = Calculate();
    }
    
    private void TestNotifiedEnumerableOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Debug.WriteLine("TestNotifiedEnumerableOnCollectionChanged called");
    }
    
    private async Task Calculate()
    {
        await Task.Delay(1000);
        uiExecutor?.Call(() => TestInt = 10);
        uiExecutor?.Call(() =>
        {
            TestCollection.Add("Should Work 3");
            TestCollection.Add("Should Work 4");
        });
        
        uiExecutor?.Call(() =>
        {
            testList.Add("ListItem1");
            testList.Add("ListItem2");
        });
    }
}