using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ToDoListDeerHacks2021;

namespace ToDoListDeerHacks2021
{
    public class FlyoutItemPage
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetPage { get; set; }
    }
}
