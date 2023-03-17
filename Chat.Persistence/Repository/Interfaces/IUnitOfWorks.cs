
namespace Chat.Persistence.Repository.Interfaces;

public interface IUnitOfWorks {
	
	public IUserRepository UserRepository { get; }
	public IMessageRepository MessageRepository { get; }


	void Save();
}

