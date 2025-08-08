using ToDoMauiApp.Model.Enums;

namespace Model.DTOs
{
    public class UpdateToDoTitemDTO
    {
        public string Title { get; set; }
        public string Decription { get; set; }
        public DateTime DeadLine { get; set; }
        public Importance Importance { get; set; }
        public Status Status { get; set; }
    }
}
