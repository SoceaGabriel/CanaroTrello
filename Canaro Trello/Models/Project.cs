using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Canaro_Trello.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectId { get; set; }
        [Display(Name = "Project title")]
        [Required(ErrorMessage = "Please enter project name.")]
        public string ProjectTitle { get; set; }
        [Display(Name = "Project descripton")]
        public string ProjectDescription { get; set; }
        [Display(Name = "Version")]
        [Required(ErrorMessage = "Please enter project version.")]
        public string Version { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Project start date")]
        [Required(ErrorMessage = "Please select project start date.")]
        public DateTime ProjectStartDate { get; set; }
        [Display(Name = "Complexity")]
        public Complexity Complexity { get; set; }
    }

    public enum Complexity
    {
        [Display(Name = "Small")]
        SMALL,
        [Display(Name = "Medium")]
        MEDIUM,
        [Display(Name = "Big")]
        BIG
    }
}