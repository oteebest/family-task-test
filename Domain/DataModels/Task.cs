using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataModels
{
    public class Task
    {
        public int Id { get; set; }
        public Guid TaskId { get; set; } = Guid.NewGuid();
        public int ? AssignedMemberId { get; set; }
        public bool IsComplete { get; set; }
        public string Subject { get; set; }
        public Member Member { get; set; }
    }
}
