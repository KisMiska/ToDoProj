
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDoMauiApp.Model;
using ToDoMauiApp.Service.Interfaces;
using ToDoMauiApp.View;

namespace ToDoMauiApp.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly IToDoService _todoService;

        public ObservableCollection<ToDoItem> ToDoList { get; } = new();

        public MainViewModel(IToDoService todoService)
        {
            _todoService = todoService;
            this.PageTitle = "ToDoList";
        }

        [RelayCommand]
        public async Task GetToDosAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                var todos = await _todoService.GetAllToDosAsync();
                ToDoList.Clear();
                foreach (var item in todos)
                {
                    ToDoList.Add(new ToDoItem(item));
                }

            } catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error", "Could not get todos" + e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task DeleteToDosAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return;
            }
            try
            {
                var succes = await _todoService.DeleteAsync(id);
                if (!succes.IsDeleteSuccesful)
                {
                    await Shell.Current.DisplaySnackbar("Could not delete todo");
                }
                else
                {
                    await GetToDosAsync();
                }
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error (Internal)", "Could not delete" + e.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task GoToAddPAge()
        {
            await Shell.Current.GoToAsync(nameof(AddTodoPage));
        }

    }
}
