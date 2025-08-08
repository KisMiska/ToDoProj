using System.ComponentModel.DataAnnotations;
using ToDoMauiApp.Model.Enums;

namespace ToDoMauiApp.Model
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public string? Description { get; set; }

        public Importance Importance { get; set; }

        public Status Status { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime Created { get; set; }

    }
}
