using PassOffice.EF.Dto;
using PassOffice.EF.Entity;

namespace PassOffice.Interfaces;

public interface IUserRepository
{
	Task<List<User>> GetUsers();
	Task AddUser(UserDto user);
	Task AddUsers(List<UserDto> users);
}