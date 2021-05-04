using Canaro_Trello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canaro_Trello.Controllers
{
    public class TasksController : Controller
    {
        public AppContext DBCotext = AppContext.Create();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTask(Guid taskId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllTasks(int? page, int sort = 1)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(Task project)
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditTask(Guid index)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditTask(Task project)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteTask(Guid index)
        {
            return View();
        }
    }
}