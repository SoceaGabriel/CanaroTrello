using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canaro_Trello.Models
{
    [Table("Task")]
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaskId { get; set; }
        [Display(Name = "Task Title")]
        [Required(ErrorMessage = "Please enter task title.")]
        public string TaskTitle { get; set; }
        [Display(Name = "State")]
        public State State { get; set; }
        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please enter task type.")]
        public string Type { get; set; }
        [Display(Name = "Priority")]
        public Priority Priority { get; set; }
        [Display(Name = "User")]
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        [Display(Name = "Assigned User")]
        public User AssignedUser { get; set; }
        [Display(Name = "Select project")]
        public Guid? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [Display(Name = "Project")]
        public Project Project { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Task Start Date")]
        [Required(ErrorMessage = "Please enter task start date.")]
        public DateTime? TaskStardDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Task End Date")]
        public DateTime? TaskEndDate { get; set; }
        [Display(Name = "Estimated Time")]
        [Required(ErrorMessage = "Please enter task estimated time.")]
        public string EstimatedTime { get; set; }
        [Display(Name = "Task Description")]  
        public string TaskDescription { get; set; }
        [Display(Name = "Select user")]
        public string UserIdString { get; set; }
        [Display(Name = "Select project")]
        public string ProjectIdString { get; set; }
    }

    public enum State
    {
        [Display(Name = "Not started")]
        NOTSTARTED,
        [Display(Name = "In progress")]
        INPROGRESS,
        [Display(Name = "Finished")]
        FINISHED
    }

    public enum Priority
    {
        [Display(Name = "Unimportant")]
        UNIMPORTANT,
        [Display(Name = "Least important")]
        LEASTIMPORTANT,
        [Display(Name = "Normal")]
        NORMAL,
        [Display(Name = "Important")]
        IMPORTANT,
        [Display(Name = "Very important")]
        VERYIMPORTANT
    }
}
