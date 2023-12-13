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
        public AddEditPage(List<TaskModel> _list)
        {
            InitializeComponent();
            list = _list;
        }

        private void Add_Clicked(object sender, EventArgs e)
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
        }
    }
}