
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.DTOs;
using ToDoMauiApp.Model.DTOs;
using ToDoMauiApp.Model.Enums;
using ToDoMauiApp.Service.Interfaces;

namespace ToDoMauiApp.ViewModel
{
    public partial class AddToDoViewModel : BaseViewModel
    {
        private readonly IToDoService _toDoService;

        [ObservableProperty]
        string title = "";

        [ObservableProperty]
        string description = "";

        [ObservableProperty]
        DateTime deadline = DateTime.UtcNow;

        [ObservableProperty]
        Importance importance = Importance.NotImportant;

        public AddToDoViewModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
            this.PageTitle = "Add To Do";
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (String.IsNullOrWhiteSpace(Title))
            {
                await Shell.Current.DisplayAlert("Error", "title is empty", "OK");
                return;
            }

            var newtodo = new CreateToDoItemDTO{
                Title = this.Title,
                Description = this.Description,
                DeadLine = this.Deadline,
                Importance = this.Importance
            };

            try
            {
                GetToDoItemDTO todo =  await _toDoService.AddAsync(newtodo);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error", "Add error" + e.Message, "OK");
                return;
            }


        }
    }
}
