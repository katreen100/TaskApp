using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.core.model
{
    public class Taskmodel
    {
       
        public int Id { set; get; }
     public string? Title {  set; get; }

public string ?Description { set; get; } 

public DateTime DueDate { set; get; }   


public string ?Status { set; get; }

 public string? AssignedTo { set; get; }
    }
}
