
using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoMauiApp.ViewModel
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string pageTitle;

        public bool IsNotBusy => !IsBusy;

    }
}
