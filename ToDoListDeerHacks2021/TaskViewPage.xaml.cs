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
    public partial class TaskViewPage : ContentPage
    {
        public TaskViewPage()
        {
            InitializeComponent();

            OnAppearing();
        }

        //This will allow me to bind it to the database
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            tasklistview.ItemsSource = await TaskService.GetAllTasks();
        }

        private async void tasklistview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selecteditem = tasklistview.SelectedItem as Models.Task;

            await TaskService.RemoveTask(selecteditem.id);
            OnAppearing();
        }
    }
}