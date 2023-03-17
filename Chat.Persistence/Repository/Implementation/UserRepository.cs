using Chat.Persistence.Repository.Interfaces;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repository.Implementation;

public class UserRepository : Repository<User>, IUserRepository {

	public UserRepository(DbContext dbContext) : base(dbContext) { }


	public IEnumerable<User> GetAllEager() {
		return _dbSet.Include(user => user.Messages).ToList();
	}

	public User? GetFirstOrDefaultEager(Func<User, bool> predicate) {
		return _dbSet.Include(user => user.Messages).FirstOrDefault(predicate);
	}
}
