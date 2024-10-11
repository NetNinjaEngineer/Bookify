namespace Bookify.Abstractions;

public class Result
{
	public bool IsSuccess { get; private set; }
	public bool IsFailure => !IsSuccess;
	public string Error { get; set; } = string.Empty;

	protected Result(bool iSuccess, string error)
	{
		IsSuccess = iSuccess;
		Error = error;
	}

	public static Result Ok() => new(true, string.Empty);
	public static Result Fail(string error) => new(false, error);
}


public class Result<T> : Result
{
	public T Value { get; private set; }

	private Result(bool isSuccess, T value, string error) : base(isSuccess, error) => Value = value;

	public static Result<T> Ok(T value) => new(true, value, string.Empty);
	public static new Result<T> Fail(string error) => new(false, default!, error);
}