using Canaro_Trello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
            TaskDTO task = DBCotext.Tasks.Select(c => new TaskDTO
            {
                TaskId = c.TaskId,
                UserId = (Guid)c.UserId,
                ProjectId = (Guid)c.ProjectId,
                AssignedUser = c.AssignedUser,
                Project = c.Project,
                EstimatedTime = c.EstimatedTime,
                Priority = c.Priority,
                State = c.State,
                TaskDescription = c.TaskDescription,
                TaskTitle = c.TaskTitle,
                Type = c.Type,
                TaskStardDate = c.TaskStardDate,
                TaskEndDate = c.TaskEndDate
            }).Where(c => c.TaskId == taskId).FirstOrDefault();
            return View(task);
        }

        [HttpGet]
        public ActionResult GetAllTasks(int? page, int sort = 1)
        {
            if (Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<TaskDTO> tasks = null;
            switch (sort)
            {
                case 1:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderBy(c => c.State).ToList();
                    break;
                case 2:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderBy(c => c.Priority).ToList();
                    break;
                case 3:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderBy(c => c.AssignedUser.FirstName).ToList();
                    break;
                case 4:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderBy(c => c.Project.ProjectTitle).ToList();
                    break;
                case 5:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderBy(c => c.TaskStardDate).ToList();
                    break;
                case 6:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderByDescending(c => c.TaskStardDate).ToList();
                    break;
                case 7:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderBy(c => c.TaskEndDate).ToList();
                    break;
                case 8:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderByDescending(c => c.TaskEndDate).ToList();
                    break;
                default:
                    tasks = DBCotext.Tasks.Where(c => c.State == State.NOTSTARTED || c.State == State.INPROGRESS).Select(c => new TaskDTO
                    {
                        TaskId = c.TaskId,
                        UserId = (Guid)c.UserId,
                        ProjectId = (Guid)c.ProjectId,
                        AssignedUser = c.AssignedUser,
                        Project = c.Project,
                        EstimatedTime = c.EstimatedTime,
                        Priority = c.Priority,
                        State = c.State,
                        TaskDescription = c.TaskDescription,
                        TaskEndDate = c.TaskEndDate,
                        TaskStardDate = c.TaskStardDate,
                        TaskTitle = c.TaskTitle,
                        Type = c.Type
                    }).OrderByDescending(c => c.TaskStardDate).ToList();
                    break;
            }
            return View(tasks.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult AddTask()
        {
            var users = DBCotext.Utilizatori.ToList();
            var projects = DBCotext.Projects.ToList();
            List<SelectListItem> usersName = new List<SelectListItem>();
            List<SelectListItem> projectList = new List<SelectListItem>();
            foreach (var usr in users)
            {
                SelectListItem sel = new SelectListItem();
                sel.Text = usr.FirstName + " " + usr.LastName;
                sel.Value = usr.UserId.ToString();
                usersName.Add(sel);
            }
            foreach (var prj in projects)
            {
                SelectListItem sel = new SelectListItem();
                sel.Text = prj.ProjectTitle;
                sel.Value = prj.ProjectId.ToString();
                projectList.Add(sel);
            }
            ViewBag.userName = usersName;
            ViewBag.projectList = projectList;
            return View();
        }

        
        [HttpPost]
        public ActionResult AddTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                if(task.TaskEndDate < task.TaskStardDate)
                {
                    ModelState.AddModelError("TaskEndDate", "Task end date is smaller than start date! Please verify.");
                    return View(task);
                }
                else if((task.TaskStardDate > DateTime.Now) && (task.State != State.NOTSTARTED))
                {
                    ModelState.AddModelError("State", "Task start date is in future and state is in progress or finished! Please verify.");
                    return View(task);
                }
                else
                {
                    Task tsk = new Task()
                    {
                        TaskTitle = task.TaskTitle,
                        TaskDescription = task.TaskDescription,
                        TaskStardDate = task.TaskStardDate,
                        TaskEndDate = task.TaskEndDate,
                        EstimatedTime = task.EstimatedTime,
                        Priority = task.Priority,
                        State = task.State,
                        Type = task.Type,
                        UserId = new Guid(task.UserIdString),
                        ProjectId = new Guid(task.ProjectIdString),
                        AssignedUser = DBCotext.Utilizatori.Where(x => x.UserId == new Guid(task.UserIdString)).FirstOrDefault(),
                        Project = DBCotext.Projects.Where(x => x.ProjectId == new Guid(task.ProjectIdString)).FirstOrDefault()
                    };
                    DBCotext.Tasks.Add(tsk);
                    DBCotext.SaveChanges();
                    return RedirectToAction("GetAllTasks", "Tasks");
                }
            }
            else
            {
                ModelState.AddModelError("TaskId", "Complete the requested fields!");
                return View(task);

            }
        }

        [HttpGet]
        public ActionResult EditTask(Guid index)
        {
            TaskDTO task = DBCotext.Tasks.Select(c => new TaskDTO
            {
               AssignedUser = c.AssignedUser,
               EstimatedTime = c.EstimatedTime,
               Priority = c.Priority,
               Project = c.Project,
               ProjectId = (Guid)c.ProjectId,
               TaskId = c.TaskId,
               State = c.State,
               TaskDescription = c.TaskDescription,
               TaskEndDate = c.TaskEndDate,
               TaskStardDate = c.TaskStardDate,
               TaskTitle = c.TaskTitle,
               Type = c.Type,
               UserId = (Guid)c.UserId,
               ProjectIdString = c.ProjectIdString,
               UserIdString = c.UserIdString
            }).Where(c => c.TaskId == index).FirstOrDefault();
            var users = DBCotext.Utilizatori.ToList();
            var projects = DBCotext.Projects.ToList();
            List<SelectListItem> usersName = new List<SelectListItem>();
            List<SelectListItem> projectList = new List<SelectListItem>();
            foreach (var usr in users)
            {
                SelectListItem sel = new SelectListItem();
                sel.Text = usr.FirstName + " " + usr.LastName;
                sel.Value = usr.UserId.ToString();
                usersName.Add(sel);
            }
            foreach (var prj in projects)
            {
                SelectListItem sel = new SelectListItem();
                sel.Text = prj.ProjectTitle;
                sel.Value = prj.ProjectId.ToString();
                projectList.Add(sel);
            }
            ViewBag.userName = usersName;
            ViewBag.projectList = projectList;
            return View(task);
        }

        [HttpPost]
        public ActionResult EditTask(Task task)
        {
            var tsk = DBCotext.Tasks.Find(task.TaskId);
            tsk.AssignedUser = DBCotext.Utilizatori.Where(x =>x.UserId == new Guid(task.UserIdString)).FirstOrDefault();
            tsk.EstimatedTime = task.EstimatedTime;
            tsk.Priority = task.Priority;
            tsk.Project = DBCotext.Projects.Where(x => x.ProjectId == new Guid(task.ProjectIdString)).FirstOrDefault();
            tsk.ProjectId = new Guid(task.ProjectIdString);
            tsk.State = task.State;
            tsk.TaskDescription = task.TaskDescription;
            tsk.TaskEndDate = task.TaskEndDate;
            tsk.TaskStardDate = task.TaskStardDate;
            tsk.TaskTitle = task.TaskTitle;
            tsk.Type = task.Type;
            tsk.UserId = new Guid(task.UserIdString);
            tsk.ProjectIdString = task.ProjectIdString;
            tsk.UserIdString = task.UserIdString;
            DBCotext.SaveChanges();
            return RedirectToAction("GetAllTasks");
        }

        [HttpGet]
        public ActionResult DeleteTask(Guid index)
        {
            var task = DBCotext.Tasks.Find(index);
            DBCotext.Tasks.Remove(task);
            DBCotext.SaveChanges();
            return RedirectToAction("GetAllTasks");
        }

        [HttpGet]
        public ActionResult Activity(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<TaskDTO> tasks = null;
            tasks = DBCotext.Tasks.Where(c => c.State == State.FINISHED).Select(c => new TaskDTO
            {
                TaskId = c.TaskId,
                UserId = (Guid)c.UserId,
                ProjectId = (Guid)c.ProjectId,
                AssignedUser = c.AssignedUser,
                Project = c.Project,
                EstimatedTime = c.EstimatedTime,
                Priority = c.Priority,
                State = c.State,
                TaskDescription = c.TaskDescription,
                TaskEndDate = c.TaskEndDate,
                TaskStardDate = c.TaskStardDate,
                TaskTitle = c.TaskTitle,
                Type = c.Type
            }).OrderByDescending(c => c.TaskEndDate).ToList();
            return View(tasks.ToPagedList(pageNumber, pageSize));
        }
    }
}