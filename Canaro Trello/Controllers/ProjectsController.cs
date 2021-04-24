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
        public ActionResult GetAllProjects(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var projects = DBCotext.Projects.Select(c => new ProjectDTO{
                ProjectId = c.ProjectId,
                ProjectDescription = c.ProjectDescription,
                Complexity = c.Complexity,
                ProjectStartDate = c.ProjectStartDate,
                ProjectTitle = c.ProjectTitle,
                Version = c.Version
            }).OrderBy(c => c.ProjectTitle).ToList();

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
            if(ModelState.IsValid)
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
                ModelState.AddModelError("ProjectTitle", "Complete the requested fields!");
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

        [HttpPut]
        public ActionResult EditProject(Project project)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteProject(Guid index)
        {
            return View();
        }
    }
}