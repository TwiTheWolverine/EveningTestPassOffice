using PassOffice.EF.Dto;
using PassOffice.EF.Entity;

namespace PassOffice.Interfaces;

public interface IPassRepository
{
	Task<List<Pass>> GetAll();
	int GetCount(DateTime issuedFrom, DateTime issuedTo);
	Task<Pass?> GetLastIssued();
	Task AddPassForUser (int userId);
	Task AddPassForUser(PassDto passDto);
	Task AddPass(List<PassDto> passDtoList);
	Task RemoveUserPass(int userId);
}