﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.core.model;

namespace TaskApp.core.DTOS
{
    public class TaskDto
    {
        public string? Title { set; get; }

        public string? Description { set; get; }

        public DateTime DueDate { set; get; }

        

        public string? Status { set; get; }

        public string? AssignedTo { set; get; }
    }
}
