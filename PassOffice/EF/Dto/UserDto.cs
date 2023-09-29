namespace PassOffice.EF.Dto;

public class UserDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string MiddleName { get; set; }

	public string FullName
	{
		get
		{
			var result = FirstName;
			if(!string.IsNullOrWhiteSpace(MiddleName))
			{
				result += $" ({MiddleName})";
			}

			result += $" {LastName}";

			return result;
		}
	}
}