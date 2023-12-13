using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMS_WebUI.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
    }
}
