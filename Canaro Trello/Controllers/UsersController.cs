using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canaro_Trello.Controllers 
{
    public class UsersController : Controller
    {
        private AppContext DBCotext = AppContext.Create();

        public ActionResult MyProfile()
        {
            return View();
        }

        public ActionResult GetUserList()
        {
            var users = DBCotext.Utilizatori.ToList();
            List<SelectListItem> usersName = new List<SelectListItem>();
            foreach (var usr in users)
            {
                SelectListItem sel = new SelectListItem();
                sel.Text = usr.FirstName + " " + usr.LastName;
                sel.Value = usr.UserId.ToString();
                usersName.Add(sel);
            }
            return Json(usersName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAdminRole(string selectedUser)
        {
            var user = DBCotext.Utilizatori.Where(x => x.UserId == new Guid(selectedUser)).FirstOrDefault();
            user.Role = Models.Roles.ADMIN;
            DBCotext.SaveChanges();
            return RedirectToAction("MyProfile", "Users");
        }

        public ActionResult GetProfileInfo(string userId)
        {
            var user = DBCotext.Utilizatori.Where(x => x.UserId == new Guid(userId)).FirstOrDefault();
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetToDoTasks(string userId)
        {
            var todoTasks = DBCotext.Tasks.Where(x => x.AssignedUser.UserId == new Guid(userId) 
            && x.State == Canaro_Trello.Models.State.NOTSTARTED).ToList();
            foreach(var tsk in todoTasks)
            {
                tsk.Project = DBCotext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(todoTasks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInProgressTasks(string userId)
        {
            var inprogressTasks = DBCotext.Tasks.Where(x => x.AssignedUser.UserId == new Guid(userId)
            && x.State == Models.State.INPROGRESS).ToList();
            foreach (var tsk in inprogressTasks)
            {
                tsk.Project = DBCotext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(inprogressTasks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFinishedTasks(string userId)
        {
            var finishedTasks = DBCotext.Tasks.Where(x => x.AssignedUser.UserId == new Guid(userId)
            && x.State == Canaro_Trello.Models.State.FINISHED).ToList();
            foreach (var tsk in finishedTasks)
            {
                tsk.Project = DBCotext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(finishedTasks, JsonRequestBehavior.AllowGet);
        }
    }
}