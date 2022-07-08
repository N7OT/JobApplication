using System.Collections.Generic;
using System.Threading.Tasks;
using JobApplication.Models;

namespace JobApplication.Data.Services
{
	public interface IUsersService
	{
		Task<IEnumerable<User>> GetAllAsync();
		Task<User> GetByIdAsync(int id);
		Task AddAsync(User user);
		Task<User> UpdateAsync(int id, User newUser);
		Task DeleteAsync(int id);
	}
}
