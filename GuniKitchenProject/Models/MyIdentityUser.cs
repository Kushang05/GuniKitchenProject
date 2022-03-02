using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GuniKitchenProject.Models
{
    public class MyIdentityUser
              : IdentityUser<Guid>
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} cannot be EMPTY !!!!")]
        [MinLength(3, ErrorMessage = "{0} cannot be less than {1} !!")]
        [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string DisplayName { get; set; }


        [Display(Name = "Phone Number")]
        [MinLength(10, ErrorMessage = "{0} cannot be less then {1}")]
        [Required(ErrorMessage = "{0} cannot be Empty!!")]
        public string MobileNo { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        [PersonalData]
        [Column(TypeName = "smalldatetime")]
        public DataType DateOfBirth { get; set; }

        [Required(ErrorMessage = "{0} ccannot be Empty!!")]
        public string Address { get; set; }

        [Display(Name = "Is Admin User")]
        [Required]
        public bool IsAdminUser { get; set; }
    }
}
