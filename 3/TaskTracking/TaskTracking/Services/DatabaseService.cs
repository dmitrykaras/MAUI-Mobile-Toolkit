using SQLite;
using SimpleTaskTracker.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SimpleTaskTracker.Services
{
    public class DatabaseService
    {
        //подключение к базе данных
        SQLiteAsyncConnection Database;

        public DatabaseService() { }

        //инициализация — создаётся база и таблица, если их нет
        async Task Init()
        {
            if (Database != null)
                return;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db3");

            Database = new SQLiteAsyncConnection(dbPath);
            await Database.CreateTableAsync<TaskItem>();
        }

        //получить все задачи
        public async Task<List<TaskItem>> GetTasksAsync()
        {
            await Init();
            return await Database.Table<TaskItem>().ToListAsync();
        }

        //добавить или обновить задачу
        public async Task<int> SaveTaskAsync(TaskItem task)
        {
            await Init();

            //если Id не 0 — обновляем
            if (task.Id != 0)
                return await Database.UpdateAsync(task);

            //если Id == 0 — новая, вставляем
            return await Database.InsertAsync(task);
        }

        //удалить задачу
        public async Task<int> DeleteTaskAsync(TaskItem task)
        {
            await Init();
            return await Database.DeleteAsync(task);
        }
    }
}