using SQLite;

namespace SimpleTaskTracker.Models
{
    //описывает одну задачу в списке
    public class TaskItem
    {
        //первичный ключ — автоинкремент (SQLite сам выдает новые id)
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //текст задачи
        public string Text { get; set; }

        //флажок: выполнена ли задача
        public bool IsDone { get; set; }
    }
}