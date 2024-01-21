using System.ComponentModel.DataAnnotations;

namespace Lumia.Areas.Manage.ViewModels
{
    public class UpdateTeamVm
    {

        public int Id { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        public string Word { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        public string Description { get; set; }


        [Required]
        public IFormFile? File { get; set; }
    }
}
