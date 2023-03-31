using System.ComponentModel.DataAnnotations;

namespace Chat.Domain.ViewModels;

public class UserAuthorizationViewModel {

	[Required]
	public String? Login { get; set; }

	[Required]
	public String? Password { get; set; }
}
