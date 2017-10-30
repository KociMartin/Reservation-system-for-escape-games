using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ASP_DU_2.Model
{
    /// <summary>
    /// Model zakaznika a validace
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name cannot be empty")]
        [StringLength(maximumLength:50,MinimumLength =1,ErrorMessage = "FirstName must contain 1 - 50 characters")]
        [Display(Name = "First Name")]   
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name cannot be empty")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "LastName must contain 1 - 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email cannot be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email adress must be in valid format")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone cannot be empty")]
        [Phone (ErrorMessage = "Phone number must be in format +420 XXX XXX XXX")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}
