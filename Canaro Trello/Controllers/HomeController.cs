using Canaro_Trello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace Canaro_Trello.Controllers
{
    public class HomeController : Controller
    {
        private AppContext DBContext = AppContext.Create();
        public ActionResult Index()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult GetLast5Tasks()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var tasks = DBContext.Tasks.Where(x => x.State == State.NOTSTARTED).Take(5).ToList();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetMostActiveUsers()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var users = DBContext.Utilizatori.Take(5).ToList();
            Dictionary<Object, int> activeUsers = new Dictionary<Object, int>();
            foreach (var usr in users)
            {
                activeUsers.Add(new { FirstName = usr.FirstName, LastName = usr.LastName, UserId = usr.UserId }, 0);
            }
            var tasks = DBContext.Tasks.ToList();
            foreach(var tsk in tasks)
            {
                var selectedUser = DBContext.Utilizatori.Where(x => x.UserId == tsk.UserId).Select(y => new { FirstName = y.FirstName, LastName = y.LastName, UserId = y.UserId }).FirstOrDefault();
                if(selectedUser != null && activeUsers.ContainsKey(selectedUser))
                {
                    activeUsers[selectedUser]++;
                }
            }
            activeUsers.OrderByDescending(x => x.Value);
            List<Object> sentUser = new List<Object>();
            foreach(var active in activeUsers)
            {
                sentUser.Add(active.Key);
            }
            return Json(sentUser, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllTODOTasks()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var todoTasks = DBContext.Tasks.Where(x => x.State == State.NOTSTARTED).ToList();
            foreach (var tsk in todoTasks)
            {
                tsk.Project = DBContext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(todoTasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllInProgressTasks()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var todoTasks = DBContext.Tasks.Where(x => x.State == State.INPROGRESS).ToList();
            foreach (var tsk in todoTasks)
            {
                tsk.Project = DBContext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(todoTasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllFinishedTasks()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var todoTasks = DBContext.Tasks.Where(x => x.State == State.FINISHED).ToList();
            foreach (var tsk in todoTasks)
            {
                tsk.Project = DBContext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(todoTasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllProjects()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var projects = DBContext.Projects.Take(20).ToList();
            return Json(projects, JsonRequestBehavior.AllowGet);
        }

    }
}