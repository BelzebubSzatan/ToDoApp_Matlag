using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Model;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        List<TaskModel> tasks = new List<TaskModel>();
        public MainPage()
        {
            InitializeComponent();
            tasks.Add(new TaskModel()
            {
                ID=Guid.NewGuid(),
                Title="123",
                Importance="Ważne",
            });
            TasksList.ItemsSource = tasks;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEditPage(tasks));
        }
    }
}
