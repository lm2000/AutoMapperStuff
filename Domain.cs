using System;

namespace AutoMapperStuff
{

    //Business Object
    public class Task
    {
        public string Name { get; set; }
        public DateTime DueTo { get; set; }
        public string GetDetails() { return "details"; }
        public TaskPriority Priority { get; set; }
        //...
    }

    //DTO
    public class TaskDto
    {
        public string Name { get; set; }
        public string DueTo { get; set; }
        public string Details { get; set; }
        public string PriorityCaption { get; set; }
    }

    public class TaskPriority
    {
        public TaskPriority()
        {
        }

        public TaskPriority(string caption)
        {
            Caption = caption;
        }

        public string Caption { get; set; }
    }
}
