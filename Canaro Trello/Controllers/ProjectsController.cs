using Canaro_Trello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Canaro_Trello.Controllers
{
    public class ProjectsController : Controller
    {
        public AppContext DBCotext = AppContext.Create();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProject(Guid index)
        {
            ProjectDTO project = DBCotext.Projects.Select(c => new ProjectDTO
            {
                ProjectId = c.ProjectId,
                ProjectDescription = c.ProjectDescription,
                Complexity = c.Complexity,
                ProjectStartDate = c.ProjectStartDate,
                ProjectTitle = c.ProjectTitle,
                Version = c.Version
            }).Where(c => c.ProjectId == index).FirstOrDefault();
            return View(project);
        }

        [HttpGet]
        public ActionResult GetAllProjects(int? page, int sort = 1)
        {
            if(Session["CanaroAuthUser"] == null || Session["CanaroAuthUser"].Equals(""))
            {
                return RedirectToAction("Index","Login");
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            IEnumerable<ProjectDTO> projects = null;
            switch(sort)
            {
                case 1:
                    projects = DBCotext.Projects.Select(c => new ProjectDTO
                    {
                        ProjectId = c.ProjectId,
                        ProjectDescription = c.ProjectDescription,
                        Complexity = c.Complexity,
                        ProjectStartDate = c.ProjectStartDate,
                        ProjectTitle = c.ProjectTitle,
                        Version = c.Version
                    }).OrderBy(c => c.ProjectTitle).ToList();
                    break;
                case 2:
                    projects = DBCotext.Projects.Select(c => new ProjectDTO
                    {
                        ProjectId = c.ProjectId,
                        ProjectDescription = c.ProjectDescription,
                        Complexity = c.Complexity,
                        ProjectStartDate = c.ProjectStartDate,
                        ProjectTitle = c.ProjectTitle,
                        Version = c.Version
                    }).OrderByDescending(c => c.ProjectTitle).ToList();
                    break;
                case 3:
                    projects = DBCotext.Projects.Select(c => new ProjectDTO
                    {
                        ProjectId = c.ProjectId,
                        ProjectDescription = c.ProjectDescription,
                        Complexity = c.Complexity,
                        ProjectStartDate = c.ProjectStartDate,
                        ProjectTitle = c.ProjectTitle,
                        Version = c.Version
                    }).OrderBy(c => c.ProjectStartDate).ToList();
                    break;
                case 4:
                    projects = DBCotext.Projects.Select(c => new ProjectDTO
                    {
                        ProjectId = c.ProjectId,
                        ProjectDescription = c.ProjectDescription,
                        Complexity = c.Complexity,
                        ProjectStartDate = c.ProjectStartDate,
                        ProjectTitle = c.ProjectTitle,
                        Version = c.Version
                    }).OrderByDescending(c => c.ProjectStartDate).ToList();
                    break;
                case 5:
                    projects = DBCotext.Projects.Select(c => new ProjectDTO
                    {
                        ProjectId = c.ProjectId,
                        ProjectDescription = c.ProjectDescription,
                        Complexity = c.Complexity,
                        ProjectStartDate = c.ProjectStartDate,
                        ProjectTitle = c.ProjectTitle,
                        Version = c.Version
                    }).OrderBy(c => c.Complexity).ToList();
                    break;
                default:
                    projects = DBCotext.Projects.Select(c => new ProjectDTO
                    {
                        ProjectId = c.ProjectId,
                        ProjectDescription = c.ProjectDescription,
                        Complexity = c.Complexity,
                        ProjectStartDate = c.ProjectStartDate,
                        ProjectTitle = c.ProjectTitle,
                        Version = c.Version
                    }).OrderBy(c => c.ProjectTitle).ToList();
                    break;
            }
            return View(projects.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            if(!ModelState.IsValid)
            {
                Project pro = new Project()
                {
                    ProjectDescription = project.ProjectDescription,
                    ProjectStartDate = project.ProjectStartDate,
                    ProjectTitle = project.ProjectTitle,
                    Complexity = project.Complexity,
                    Version = project.Version
                };
                DBCotext.Projects.Add(pro);
                DBCotext.SaveChanges();
                return RedirectToAction("GetAllProjects");
            }
            else
            {
                ModelState.AddModelError("ProjectId", "Complete the requested fields!");
                return View(project);
            }
            
     
        }

        [HttpGet]
        public ActionResult EditProject(Guid index)
        {
            ProjectDTO pro = DBCotext.Projects.Select(c => new ProjectDTO
            {
                ProjectId = c.ProjectId,
                ProjectDescription = c.ProjectDescription,
                Complexity = c.Complexity,
                ProjectStartDate = c.ProjectStartDate,
                ProjectTitle = c.ProjectTitle,
                Version = c.Version
            }).Where(c => c.ProjectId == index).FirstOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            var pro = DBCotext.Projects.Find(project.ProjectId);
            pro.ProjectDescription = project.ProjectDescription;
            pro.Complexity = project.Complexity;
            pro.ProjectStartDate = project.ProjectStartDate;
            pro.ProjectTitle = project.ProjectTitle;
            pro.Version = project.Version;
            DBCotext.SaveChanges();
            return RedirectToAction("GetAllProjects");
        }

        [HttpGet]
        public ActionResult DeleteProject(Guid index)
        {
            var pro = DBCotext.Projects.Find(index);
            DBCotext.Projects.Remove(pro);
            DBCotext.SaveChanges();
            return RedirectToAction("GetAllProjects");
        }
    }
}