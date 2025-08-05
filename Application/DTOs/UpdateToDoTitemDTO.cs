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
        public string Title;
        public string Decription;
        public DateTime DeadLine;
        public Importance Importance;
        public Status Status;
    }
}
