using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GuniKitchenProject.Data;
using GuniKitchenProject.Models;
using GuniKitchenProject.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuniKitchenProject.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;


        public IndexModel(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }



        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Date of Birth")]
            [Required]
            [PersonalData]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "{0} ccannot be Empty!!")]
            public string Address { get; set; }

            [Required]
            [PersonalData]
            [Display(Name = "Gender")]
            public MyIdentityGenders Gender { get; set; }

            [Display(Name = "Is Admin User")]
            [Required]
            public bool IsAdminUser { get; set; }

        }

        private async Task LoadAsync(MyIdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Gender = user.Gender,
                IsAdminUser = user.IsAdminUser
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            bool hasChangedPhoneNumber = false;
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                { 
                    hasChangedPhoneNumber = true;
                }
                else 
                { 
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            bool hasOtherChanges = false;

            if(Input.DateOfBirth != user.DateOfBirth)
            {
                user.DateOfBirth = Input.DateOfBirth;
                hasOtherChanges = true;
            }
            if(Input.Gender != user.Gender)
            {
                user.Gender = Input.Gender;
                hasOtherChanges = true;
            }
            if(Input.Address != user.Address)
            {
                user.Address = Input.Address;
                hasOtherChanges = true;
            }
            if(hasChangedPhoneNumber || hasOtherChanges)
            {
                _dbContext.SaveChanges();
                this.StatusMessage = "Your profile has been updated:";
                await _signInManager.RefreshSignInAsync(user);
            }
            //await _signInManager.RefreshSignInAsync(user);
            //StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
