using Microsoft.Maui.Controls;
using SimpleTaskTracker.Models;
using SimpleTaskTracker.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TaskTracking
{
    public partial class MainPage : ContentPage
    {
        //работа с базой
        DatabaseService databaseService;

        //коллекция с задачами — обновляет UI автоматически
        ObservableCollection<TaskItem> tasks;

        public MainPage()
        {
            InitializeComponent();

            databaseService = new DatabaseService();
            tasks = new ObservableCollection<TaskItem>();

            //привязываем коллекцию к CollectionView
            TasksCollectionView.ItemsSource = tasks;

            //загружаем задачи
            _ = LoadTasks();
        }

        //загружается при появлении страницы
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTasks();
        }

        //загрузить все задачи из базы
        async Task LoadTasks()
        {
            var tasksList = await databaseService.GetTasksAsync();

            tasks.Clear();

            foreach (var task in tasksList)
                tasks.Add(task);
        }

        //добавить новую задачу
        async void OnAddTaskClicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskEntry.Text))
                return;

            var newTask = new TaskItem
            {
                Text = TaskEntry.Text.Trim()
            };

            await databaseService.SaveTaskAsync(newTask);

            TaskEntry.Text = string.Empty;

            await LoadTasks();
        }

        //переключение чекбокса (выполнено/не выполнено)
        async void OnTaskToggled(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox cb && cb.BindingContext is TaskItem task)
            {
                await databaseService.SaveTaskAsync(task);
            }
        }

        //удаление задачи
        async void OnDeleteTaskClicked(object sender, System.EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is TaskItem task)
            {
                await databaseService.DeleteTaskAsync(task);
                await LoadTasks();
            }
        }
    }
}