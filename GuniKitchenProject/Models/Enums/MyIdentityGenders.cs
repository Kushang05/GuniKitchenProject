using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuniKitchenProject.Models.Enums
{
    public enum MyIdentityGenders
    {

        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female,

        [Display(Name = "Third Gender")]
        ThirdGender

    }
}

