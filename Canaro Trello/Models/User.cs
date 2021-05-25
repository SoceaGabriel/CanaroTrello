using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canaro_Trello.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }
        [Display(Name = "Confirmed Password")]
        [Required(ErrorMessage = "Please enter confirmed password.")]
        public string ConfirmedPassword { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Birth Day")]
        [Required(ErrorMessage = "Please enter your birthday.")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Role")]
        public Roles? Role { get; set; }
    }

    public enum Roles
    {
        [Display(Name = "Admin")]
        ADMIN,
        [Display(Name = "Moderator")]
        MODERATOR,
        [Display(Name = "User")]
        NORMAL_USER
    }
}