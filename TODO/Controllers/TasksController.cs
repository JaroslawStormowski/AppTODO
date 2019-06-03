using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODO.Models;

namespace TODO.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ViewAll()
        {
            AllTasksViewModel allTasks = new AllTasksViewModel();

            return View("ViewAll", allTasks);
        }

        //Edit existing task, get it by id
        public ActionResult AddOrEdit(int id=0)
        {
            Task task = new Task();
            if (id != 0)
            {
                task = new AllTasks().GetTask(id);
            }

            return View(task);
        }

        //Add new task, do it with data from html
        [HttpPost]
        public ActionResult AddOrEdit(Task task)
        {
            if (task.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(task.ImageUpload.FileName);
                string extension = Path.GetExtension(task.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                task.ImagePath = "~/AppFiles/Images/" + fileName;
                task.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images"), fileName));
            }

            if (task.Id == 0) //generate new task
            {
                TODO.Models.AllTasks.Taskscount += 1;
                task.Id = TODO.Models.AllTasks.Taskscount;
                new AllTasks().AddTask(task);
            }
            else //edit task with certain id 
            {

                var tlist = TODO.Models.AllTasks.All;
                Task taskToReplace = new AllTasks().GetTask(task.Id);
                int index = tlist.IndexOf(taskToReplace);
                tlist.RemoveAt(index);
                tlist.Insert(index, task);
            }

            return RedirectToRoute(new
            {
                controller = "Tasks",
                action = "Index",
            });
        }

        //Delete task
        public ActionResult Delete(int id)
        {
            var tlist = TODO.Models.AllTasks.All;
            Task task = new AllTasks().GetTask(id);
            int index = tlist.IndexOf(task);
            tlist.RemoveAt(index);

            return RedirectToRoute(new
            {
                controller = "Tasks",
                action = "Index",
            });
        }
    }
}