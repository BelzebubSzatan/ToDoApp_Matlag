using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditPage : ContentPage
    {
        List<TaskModel> list;
        TaskModel taskModel;
        public AddEditPage(List<TaskModel> _list)
        {
            InitializeComponent();
            list = _list;
        }
        public AddEditPage(List<TaskModel> list,TaskModel model)
        {
            InitializeComponent();
            this.list = list;
            taskModel=model;
            TitleEntry.Text = taskModel.Title;
            IsImportant.IsChecked=taskModel.Importance==""?false:true;

            Add.Clicked -= Add_Clicked;
            Add.Clicked += Edit_Clicked;
            Add.Text = "Edytuj";
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            taskModel.Title = TitleEntry.Text;
            if (IsImportant.IsChecked)
            {
                taskModel.Importance = "Ważne";
            }
            else
                taskModel.Importance = "";

            JSON.JSONHandling.WriteToFile(list);
            await Navigation.PopToRootAsync();

        }
        private async void Add_Clicked(object sender, EventArgs e)
        {
            TaskModel task = new TaskModel();
            task.ID = Guid.NewGuid();
            task.Title = TitleEntry.Text;
            if (IsImportant.IsChecked)
            {
                task.Importance = "Ważne";
            }
            else
                task.Importance = "";
            list.Add(task);

            JSON.JSONHandling.WriteToFile(list);
            await Navigation.PopToRootAsync();
        }
    }
}