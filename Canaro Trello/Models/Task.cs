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
        public string TaskTitle { get; set; }
        public State State { get; set; }
        public string Type { get; set; }
        public Priority Priority { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public User AssignedUser { get; set; }
        public Guid? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TaskStardDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TaskEndDate { get; set; }
        public string EstimatedTime { get; set; }
        public string TaskDescription { get; set; }
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
