using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODO.Models
{
    public class AllTasksViewModel
    {
        public List<Task> AllTasks
        {
            get
           {

                return TODO.Models.AllTasks.All;
           }

        }



    }
}