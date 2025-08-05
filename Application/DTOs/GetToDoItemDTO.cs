using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models.Enums;

namespace Application.DTOs
{
    public class GetToDoItemDTO
    {
        public string Name;
        public string Description;
        public DateTime Deadline;
        public Importance Importance;
        public Status Status;
        public Guid Guid;
        // public DateTime created;
    }
}
