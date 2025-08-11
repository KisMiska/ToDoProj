using ToDoMauiApp.View;

namespace ToDoMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddTodoPage), typeof(AddTodoPage));
        }
    }
}
