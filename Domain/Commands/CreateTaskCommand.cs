using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public class CreateTaskCommand
    {
        public string AssignedMemberId { get; set; }       
        public string Subject { get; set; }
    }
}
