using System.ComponentModel.DataAnnotations;

namespace Lumia.ViewModels
{
	public class LoginVm
	{
		[Required]
		[MinLength(5)]
		[MaxLength(30)]
		public string UserNameOrEmail { get; set; }

		[Required]
		[MinLength(6)]
		[MaxLength(15)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
    }
}
