using PassOffice.EF.Dto;

namespace PassOffice;

public static class Simulation
{
	private static Random random = new Random();
	const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

	public static List<UserDto> GenerateRandomUsers(int count)
	{
		var usersCount = count > 0 ? count : 1;
		var result = new List<UserDto>();
		for(int i = 0; i < usersCount; i++)
		{
			result.Add( new UserDto 
			{ 
				FirstName = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray()),
				MiddleName = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray()),
				LastName = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray())
			});
		}

		return result;
	}

	public static List<PassDto> GeneratePassList(List<int> userIds)
	{
		var result = new List<PassDto>();
		foreach(var userId in userIds)
		{
			var issued = DateTime.Now.AddDays(random.Next(-1000, -10));
			var validFrom = issued.AddDays(random.Next(0, 10));

			result.Add(new PassDto
			{
				Status = PassStatusEnum.Aproved,
				Type = (PassTypeEnum)random.Next(1, 3),
				IssueDate = issued,
				UserId = userId,
				ValidFrom = validFrom,
				ValidTo = validFrom.AddDays(random.Next(1, 1000))
			});
		}

		return result;
	}
}