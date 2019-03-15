using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// property class for db sync- still to be changed
namespace ToDoWebAPI.Modules
{
    public class ToDo
    {
        public  int ID { get; set; }
        public string Title { get; set; }
        public bool isDone { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
