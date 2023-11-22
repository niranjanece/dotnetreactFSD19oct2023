using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemApplication.Models.DTOs
{
    public class UserRegisterDTO : UserLoginDTO
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Retype is required")]
        [Compare("Password",ErrorMessage ="Password and Retype should be same")]
        public string RetypePassword { get; set; }
    }
}
