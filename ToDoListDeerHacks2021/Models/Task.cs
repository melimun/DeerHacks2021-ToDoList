using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListDeerHacks2021.Models
{
    internal class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }

    }
}
