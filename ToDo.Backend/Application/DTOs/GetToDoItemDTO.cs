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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Importance Importance { get; set; }
        public Status Status { get; set; }
        public Guid Guid { get; set; }
        // public DateTime created;
    }
}
