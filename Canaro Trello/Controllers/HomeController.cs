using Canaro_Trello.Models;
using Newtonsoft.Json;
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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetLast5Tasks()
        {
            var tasks = DBContext.Tasks.Where(x => x.State == State.NOTSTARTED).Take(5).ToList();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetMostActiveUsers()
        {
            var users = DBContext.Utilizatori.ToList();
            Dictionary<Object, int> activeUsers = new Dictionary<Object, int>();
            foreach (var usr in users)
            {
                activeUsers.Add(new { FirstName = usr.FirstName, LastName = usr.LastName, UserId = usr.UserId }, 0);
            }
            var tasks = DBContext.Tasks.ToList();
            foreach(var tsk in tasks)
            {
                var selectedUser = DBContext.Utilizatori.Where(x => x.UserId == tsk.UserId).Select(y => new { FirstName = y.FirstName, LastName = y.LastName, UserId = y.UserId }).FirstOrDefault();
                if(selectedUser != null)
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
            
            //string jsonResult = JsonConvert.SerializeObject(activeUsers);
            return Json(sentUser, JsonRequestBehavior.AllowGet);
        }
    }
}