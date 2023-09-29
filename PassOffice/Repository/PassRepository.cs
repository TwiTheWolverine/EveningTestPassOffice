using Microsoft.EntityFrameworkCore;
using PassOffice.EF.Dto;
using PassOffice.EF.Entity;
using PassOffice.Interfaces;

namespace PassOffice.Repository;

public class PassRepository : IPassRepository
{
	private readonly DbContext _dbContext;

	public PassRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddPass(List<PassDto> passDtoList)
	{
		var userIds = passDtoList.Select(x => x.UserId).ToList();
		await RemoveForUsers(userIds);

		foreach(var pass in passDtoList)
		{
			_dbContext.Add(new Pass
			{
				Status = pass.Status,
				IssueDate = pass.IssueDate,
				UserId = pass.UserId,
				Type = pass.Type,
				ValidFrom = pass.ValidFrom
			});
		}

		await _dbContext.SaveChangesAsync();
	}

	public async Task AddPassForUser(int userId)
	{
		await RemoveForUsers(new List<int> { userId});
		_dbContext.Add(new Pass
		{
			Status = PassStatusEnum.Awaited,
			IssueDate = DateTime.Now,
			UserId = userId,
			Type = PassTypeEnum.Urgent,
			ValidFrom = DateTime.Now
		});

		await _dbContext.SaveChangesAsync();
	}

	public async Task AddPassForUser(PassDto passDto)
	{
		await AddPass(new List<PassDto> { passDto });
	}

	public async Task<List<Pass>> GetAll()
	{
		return await (from x in _dbContext.Set<Pass>() where x.Status != PassStatusEnum.Deleted select x).AsNoTracking().ToListAsync();
	}

	public int GetCount(DateTime issuedFrom, DateTime issuedTo)
	{
		var result = (from x in _dbContext.Set<Pass>() 
					  where x.Status != PassStatusEnum.Deleted  
					  && x.IssueDate >= issuedFrom && x.IssueDate <= issuedTo
					  select x)?.Count();

		return result ?? 0;
	}

	public async Task<Pass?> GetLastIssued()
	{
		var result = await (from x in _dbContext.Set<Pass>() where x.Status != PassStatusEnum.Deleted orderby x.IssueDate descending select x ).Take(1).FirstOrDefaultAsync();

		return result;
	}

	public async Task RemoveUserPass(int userId)
	{
		await RemoveForUsers(new List<int> { userId });
	}

	private async Task RemoveForUsers(List<int> userIds)
	{
		var existPass = await (from x in _dbContext.Set<Pass>() where userIds.Contains(x.UserId) && x.Status != PassStatusEnum.Deleted select x).ToListAsync();

		if (existPass != null && existPass.Any())
		{
			foreach (var pass in existPass)
			{
				pass.Status = PassStatusEnum.Deleted;
			}
		}

		await _dbContext.SaveChangesAsync();
	}
}