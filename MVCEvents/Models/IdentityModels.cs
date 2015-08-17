using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace MVCEvents.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Required(ErrorMessage = "Please insert first-name")]
        [Display(Name = "First-Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please insert last-name")]
        [Display(Name = "Last-Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please insert date of birth")]
        [Display(Name = "Date-Of-Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please insert email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The email address is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Please insert user-name")]
        [Display(Name = "User-Name")]
        public override string UserName { get; set; }

        [Display(Name = "confirm")]
        public override bool EmailConfirmed { get; set; }

        public string ConfirmationToken { get; set; }

        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", HtmlEncode = true, ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}