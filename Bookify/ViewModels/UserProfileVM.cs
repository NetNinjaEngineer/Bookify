namespace Bookify.ViewModels;

public class UserProfileVM
{
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string UserName { get; set; } = string.Empty;
	public string PictureUrl { get; set; } = string.Empty;
	public IFormFile? ProfilePicture { get; set; }
	public string Fullname => $"{FirstName} {LastName}";
}
