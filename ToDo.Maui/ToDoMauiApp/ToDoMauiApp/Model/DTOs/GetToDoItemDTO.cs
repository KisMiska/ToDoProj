using ToDoMauiApp.Model.Enums;

namespace Model.DTOs
{
    public class GetToDoItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Importance Importance { get; set; }
        public Status Status { get; set; }
        public Guid Guid { get; set; }
        // public DateTime created;
    }
}
