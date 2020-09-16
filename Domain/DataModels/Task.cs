﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataModels
{
    public class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AssignedMemberId { get; set; }
        public bool IsComplete { get; set; }
        public string Subject { get; set; }
        public Member Member { get; set; }
    }
}
