using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace TODO.Models
{
    public class AllTasks
    {
        public static List<Task> All { get; set; } = new List<Task>();

        public static int Taskscount { get; set; }
        /*
       public AllTasks()
       {
           All = new List<Task>();
           All.Add(new Task(){Id=1, Name = "Give a lift", Text = "Go by car and take valentina"});
           All.Add(new Task(){Id=2, Name = "Do App", Text = "Write some code"});
       }
       */

        public void AddTask(Task task)
        {


            All.Add(new Task()
            {
                Id = task.Id,
                Name = task.Name,
                Text = task.Text,
                ImagePath = task.ImagePath,
                ImageUpload = task.ImageUpload,
            });
        }

        /*
        public void Remove(int Id)
        {
            Task task = GetTask(Id);

            foreach (task in All)
            {

                if (task.Id == Id)
                {
                    int index = All.IndexOf(task);
                    TODO.Models.AllTasks.All.RemoveAt(index);
                }
            }
        }*/

        public Task GetTask(int Id)
        {
            try
            {
                foreach (var task in All)
                {
                    if (task.Id == Id)
                    {
                        return task;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred '{0}'", e);
            }

            return null;
        }

        public Task GetTask(string Name)
        {
            try
            {
                foreach (var task in All)
                {
                    if (task.Name == Name)
                    {
                        return task;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred '{0}'", e);
            }

            return null;
        }

    }
}