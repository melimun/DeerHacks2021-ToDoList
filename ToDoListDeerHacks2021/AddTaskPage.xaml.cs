using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDeerHacks2021.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListDeerHacks2021
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        public AddTaskPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await TaskService.AddTask(titleEntry.Text, dateEntry.Date.ToString("MMyyyy"), descriptionEntry.Text);
            await TaskService.GetAllTasks();
            await DisplayAlert("Added Task", "Successfully Added Task", "Ok");

            await Navigation.PushAsync(new TaskViewPage());

        }

        public void IsButtonEnabled(string entry1, string entry2, string entry3)
        {
            if ((entry1 == "") && (entry2 == "") && (entry3 == ""))
            {
                submitbtn.IsEnabled = false;
            }
            else
            {
                submitbtn.IsEnabled = true;
            }
        }

        //ToDo: Fix up the button 
        private void Label_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsButtonEnabled(titleEntry.Text, dateEntry.Date.ToString(), descriptionEntry.Text);

        }
    }
}