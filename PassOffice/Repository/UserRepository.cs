using Microsoft.EntityFrameworkCore;
using PassOffice.EF.Dto;
using PassOffice.EF.Entity;
using PassOffice.Interfaces;

namespace PassOffice.Repository;

public class UserRepository : IUserRepository
{
	private readonly DbContext _dbContext;

	public UserRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddUser(UserDto user)
	{
		if(user is null)
		{
			return;
		}

		_dbContext.Add<User>(new User
		{
			FirstName = user.FirstName,
			LastName = user.LastName,
			MiddleName = user.MiddleName,
			Description = user.FullName
		});

		await _dbContext.SaveChangesAsync();
	}

	public async Task AddUsers(List<UserDto> users)
	{
		if(users == null || !users.Any())
		{
			return;
		}

		foreach(var user in users)
		{
			_dbContext.Add<User>(new User
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				MiddleName = user.MiddleName,
				Description = user.FullName
			});
		}

		await _dbContext.SaveChangesAsync();
	}

	public async Task<List<User>> GetUsers()
	{
		return await (from x in _dbContext.Set<User>() select x).AsNoTracking().ToListAsync();
	}
}