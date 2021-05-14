using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Canaro_Trello.Models
{
    public class TaskDTO
    {
        public Guid TaskId { get; set; }
        [Display(Name = "Task Title")]
        public string TaskTitle { get; set; }
        [Display(Name = "State")]
        public State State { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Priority")]
        public Priority Priority { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "Assigned User")]
        public User AssignedUser { get; set; }
        public Guid ProjectId { get; set; }
        [Display(Name = "Project")]
        public Project Project { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Task Start Date")]
        public DateTime? TaskStardDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Task End Date")]
        public DateTime? TaskEndDate { get; set; }
        [Display(Name = "Estimated Time")]
        public string EstimatedTime { get; set; }
        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; }
        [Display(Name = "Select user")]
        public string UserIdString { get; set; }
        [Display(Name = "Select project")]
        public string ProjectIdString { get; set; }
    }
}