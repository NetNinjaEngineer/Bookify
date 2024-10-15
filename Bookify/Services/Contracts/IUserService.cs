namespace Bookify.Services.Contracts;

public interface IUserService
{
	string UserEmail { get; }
	Task<string> GetUserProfilePath();
	Task<string> GetLoggedInUserPictureName();
}
