using ToDoMauiApp.ViewModel;

namespace ToDoMauiApp.View;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPage(AddToDoViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}