using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pms_core_api.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string UserdDetails { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string EmailId { get; set; }
        public int HospitlId { get; set; }
    }
}

