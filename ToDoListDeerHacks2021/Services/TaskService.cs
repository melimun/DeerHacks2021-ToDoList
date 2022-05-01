using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ToDoListDeerHacks2021.Models;
using SQLite;
using Xamarin.Essentials;

namespace ToDoListDeerHacks2021.Services
{
    internal static class TaskService
    {
        static SQLiteAsyncConnection db;

        static async System.Threading.Tasks.Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "TaskDataNew.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Models.Task>();
        }

        public static async System.Threading.Tasks.Task AddTask(string name, string date, string description)
        {
            await Init();
            Guid myuuid = Guid.NewGuid();
            var task = new Models.Task
            {
                id = myuuid,
                name = name,
                date = date,
                description = description
            };

            await db.InsertAsync(task);

        }

        public static async System.Threading.Tasks.Task RemoveTask(Guid id)
        {
            await Init();

            await db.DeleteAsync<Models.Task>(id);
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            await Init();

            var task = await db.Table<Models.Task>().ToListAsync();

            return task;
        }

    }
}
