using Chat.Domain.Entities;

namespace Chat.Persistence.Repository.Interfaces;

public interface IUserRepository : IRepository<User> {

	IEnumerable<User> GetAllEager();
	User? GetFirstOrDefaultEager(Func<User, bool> predicate);
}
