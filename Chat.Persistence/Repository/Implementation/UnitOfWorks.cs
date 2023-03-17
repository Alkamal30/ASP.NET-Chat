
using Chat.Persistence.Repository.Interfaces;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repository.Implementation;

public class UnitOfWorks : IUnitOfWorks {

	public UnitOfWorks(ChatDbContext dbContext) {
		_dbContext = dbContext;

		UserRepository = new UserRepository(dbContext);
		MessageRepository = new MessageRepository(dbContext);
	}

	
	public IUserRepository UserRepository { get; }
	public IMessageRepository MessageRepository { get; }

	private DbContext _dbContext;


	public void Save() {
		_dbContext.SaveChanges();
	}
}
