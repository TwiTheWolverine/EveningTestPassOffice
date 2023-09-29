using Microsoft.EntityFrameworkCore;
using PassOffice;
using PassOffice.EF;
using PassOffice.Interfaces;
using PassOffice.Repository;


DbContext dbContext = new PassDbContext();
IUserRepository userRepository = new UserRepository(dbContext);
IPassRepository passRepository = new PassRepository(dbContext);

try
{
	var users = await userRepository.GetUsers();
	if(users == null || users.Count < 1)
	{
		await userRepository.AddUsers(Simulation.GenerateRandomUsers(5));
		users = await userRepository.GetUsers();
	}

	var passList = await passRepository.GetAll();
	if(passList == null || passList.Count < 1)
	{
		await passRepository.AddPass(Simulation.GeneratePassList(users.Select(x => x.Id).ToList()));
		passList = await passRepository.GetAll();
	}
	
	var lastIssued = await passRepository.GetLastIssued();
	Console.WriteLine($"Last issued date is {lastIssued?.IssueDate.ToString("yyyy-MM-dd")}");

	var count = passRepository.GetCount(DateTime.Now.AddDays(-500), DateTime.Now);
	Console.WriteLine($"Count {count}");
}
catch(Exception ex)
{
	throw new Exception($"Oops {ex.Message}");
}

