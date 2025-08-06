using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models.Enums;

namespace Application.DTOs
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
