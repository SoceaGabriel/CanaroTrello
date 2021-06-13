using Canaro_Trello.Models;
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
        [HttpGet]
        public ActionResult MyProfile()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var usrid = Session["CanaroAuthUserId"].ToString();
            var user = DBCotext.Utilizatori.Where(x => x.UserId == new Guid(usrid)).FirstOrDefault();
            UserDTO sendUser = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserId = user.UserId,
                BirthDay = user.BirthDay,
                ConfirmedPassword = user.ConfirmedPassword,
                Password = user.Password
            };
            return View(sendUser);
        }

        [HttpGet]
        public ActionResult GetUserList()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
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

        [HttpPost]
        public ActionResult GetAdminRole(string selectedUser)
        {
            var user = DBCotext.Utilizatori.Where(x => x.UserId == new Guid(selectedUser)).FirstOrDefault();
            user.Role = Models.Roles.ADMIN;
            DBCotext.SaveChanges();

            return RedirectToAction("MyProfile", "Users");
        }

        [HttpGet]
        public ActionResult GetProfileInfo(string userId)
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var user = DBCotext.Utilizatori.Where(x => x.UserId == new Guid(userId)).FirstOrDefault();
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateProfileInfo(UserDTO userDTO)
        {
            if(userDTO.Password != userDTO.ConfirmedPassword)
            {
                ModelState.AddModelError("Password", "Password does not match confirmed password !");
                return RedirectToAction("MyProfile", "Users");
            }
            else
            {
                var updateUser = DBCotext.Utilizatori.Where(x => x.UserId == userDTO.UserId).FirstOrDefault();
                updateUser.FirstName = userDTO.FirstName;
                updateUser.LastName = userDTO.LastName;
                updateUser.Email = userDTO.Email;
                updateUser.BirthDay = userDTO.BirthDay;
                updateUser.ConfirmedPassword = userDTO.ConfirmedPassword;
                updateUser.Password = userDTO.Password;
                DBCotext.SaveChanges();
                Session["CanaroAuthUser"] = updateUser.FirstName + " " + updateUser.LastName;
                Session["CanaroAuthUserId"] = updateUser.UserId;
                Session["CanaroAuthEmail"] = updateUser.Email;
                Session["CanaroAuthRole"] = updateUser.Role;
                return RedirectToAction("MyProfile","Users");
            }
        }

        [HttpGet]
        public ActionResult GetToDoTasks(string userId)
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var todoTasks = DBCotext.Tasks.Where(x => x.AssignedUser.UserId == new Guid(userId) 
            && x.State == Canaro_Trello.Models.State.NOTSTARTED).ToList();
            foreach(var tsk in todoTasks)
            {
                tsk.Project = DBCotext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(todoTasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetInProgressTasks(string userId)
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
            var inprogressTasks = DBCotext.Tasks.Where(x => x.AssignedUser.UserId == new Guid(userId)
            && x.State == Models.State.INPROGRESS).ToList();
            foreach (var tsk in inprogressTasks)
            {
                tsk.Project = DBCotext.Projects.Where(x => x.ProjectId == tsk.ProjectId).FirstOrDefault();
            }
            return Json(inprogressTasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetFinishedTasks(string userId)
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }
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