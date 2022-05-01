using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoListDeerHacks2021.Models
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public Guid id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public string details { 
            get 
            {
                return $"Task : {name} \n Date Due : {date} \n Description : \n {description}";
            }
        }

    }
}
