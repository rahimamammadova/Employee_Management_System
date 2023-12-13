using System.ComponentModel.DataAnnotations;

namespace EMS_WebUI.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name ="Role name")]
        [Required (ErrorMessage="Role name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid RoleId { get; set; }
    }
}
