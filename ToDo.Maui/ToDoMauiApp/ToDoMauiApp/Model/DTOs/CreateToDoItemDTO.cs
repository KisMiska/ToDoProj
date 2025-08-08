using ToDoMauiApp.Model.Enums;

namespace ToDoMauiApp.Model.DTOs
{
    public class CreateToDoItemDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DeadLine { get; set; }
        public Importance Importance { get; set; } = Importance.NotImportant;
    }
}
