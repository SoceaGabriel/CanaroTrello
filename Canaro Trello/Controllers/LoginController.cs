using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Canaro_Trello.Models;


namespace Canaro_Trello.Controllers
{
    public class LoginController : Controller
    {
        AppContext DBContext = AppContext.Create();
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            var usr = DBContext.Utilizatori.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if(email != "" && password != "")
                {
                    if (usr != null)
                    {
                        Session["CanaroAuthUser"] = usr.FirstName + " " + usr.LastName;
                        Session["CanaroAuthUserId"] = usr.UserId;
                        Session["CanaroAuthEmail"] = usr.Email;
                        Session["CanaroAuthRole"] = usr.Role;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user does not exist in the database. Don't have an account? You can create one by clicking the Register button.");
                        return View(usr);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please enter username and password");
                    return View(usr);
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(usr);
            }
            
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var usr = DBContext.Utilizatori.Where(u => u.Email == user.Email).FirstOrDefault();
                if (usr != null)
                {
                    ModelState.AddModelError("", "The email " + user.Email + " already exists in database!");
                    return View();
                }
                else if(user.Password != user.ConfirmedPassword)
                {
                    ModelState.AddModelError("", "Password and confirmed password do not match!");
                    return View();
                }
                else
                {
                    int count = DBContext.Utilizatori.Count();
                    User utilizator = new User()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        ConfirmedPassword = user.ConfirmedPassword,
                        BirthDay = user.BirthDay,
                        Role = count > 0 ? Roles.NORMAL_USER : Roles.ADMIN
                    };
                    DBContext.Utilizatori.Add(utilizator);
                    DBContext.SaveChanges();
                    Session["CanaroAuthUser"] = user.FirstName + " " + user.LastName;
                    Session["CanaroAuthEmail"] = user.Email;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please complete the requested fields!");
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["CanaroAuthUser"] = ""; 
            Session["CanaroAuthEmail"] = "";
            return RedirectToAction("Index", "Login");
        }
    }
}