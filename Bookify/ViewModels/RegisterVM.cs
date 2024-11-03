using System.ComponentModel.DataAnnotations;

namespace Bookify.ViewModels;

public class RegisterVM
{
	[Required(ErrorMessage = "First name is required")]
	public string? FirstName { get; set; }

	[Required(ErrorMessage = "Last name is required")]
	public string? LastName { get; set; }

	[Required(ErrorMessage = "Username is required")]
	public string? UserName { get; set; }

	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email address")]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Password is required")]
	[DataType(DataType.Password)]
	public string? Password { get; set; }

	public IFormFile Picture { get; set; }
}
