using System.ComponentModel.DataAnnotations;

namespace Chat.Domain.ViewModels;

public class UserRegistrationViewModel {

	[Required]
	[MinLength(6)]
	public String? Login { get; set; }

	[Required]
	[MinLength(6)]
	public String? Password { get; set; }

	[Required]
	[Compare("Password")]
	public String? ConfirmPassword { get; set; }
}
