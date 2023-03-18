using Chat.Domain.Entities;

namespace Chat.Application.Interfaces.Repository;

public interface IUserRepository : IRepository<User> {

	IEnumerable<User> GetAllEager();
	User? GetFirstOrDefaultEager(Func<User, bool> predicate);
}
