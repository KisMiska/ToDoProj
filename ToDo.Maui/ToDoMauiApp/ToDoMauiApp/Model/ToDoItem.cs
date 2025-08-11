using Model.DTOs;
using System.ComponentModel.DataAnnotations;
using ToDoMauiApp.Model.Enums;

namespace ToDoMauiApp.Model
{
    public class ToDoItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public string? Description { get; set; }

        public Importance Importance { get; set; }

        public Status Status { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime Created { get; set; }

        public ToDoItem() { }

        public ToDoItem(GetToDoItemDTO dto)
        {
            Id = dto.Guid;
            Title = dto.Name;
            Description = dto.Description;
            Importance = dto.Importance;
            Status = dto.Status;
            Deadline = dto.Deadline;
        }

    }
}
