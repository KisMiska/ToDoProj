using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models.Enums;

namespace ToDo.Core.Models
{
    public class ToDoItem
    {
        public Guid id { get; set; }

        public string title { get; set; } = String.Empty;

        public string? description { get; set; }

        public Importance importance { get; set; }

        public Status status { get; set; }

        public DateTime? deadline { get; set; }

        public DateTime created { get; set; }

    }
}
